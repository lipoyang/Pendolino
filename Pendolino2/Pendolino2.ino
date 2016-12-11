#include <MsTimer2.h>
#include <Wire.h>
#include <I2Cdev.h>
#include <EEPROM.h>
#include <MPU6050.h>
#include <math.h>
#include "common.h"

// ピン番号 (デジタル)
#define MOTOR_L_IN1    2
#define SERVO_PWM      3
#define MOTOR_L_IN2    4
#define MOTOR_L_PWM    5
#define MOTOR_R_PWM    6
#define MOTOR_R_IN1    7
#define MOTOR_R_IN2    8
#define LED_L_PWM      9
#define LED_R_PWM     10

// ピン番号 (アナログ)
#define ANALOG_0      0
#define ANALOG_1      1
#define ANALOG_2      2
#define ANALOG_3      3
#define MODE_CHECK    6
#define BATT_CHECK    7

MPU6050 accelgyro;

int t;
float theta_acc, omega, theta_gyro, theta;
float x;
float v;
float ka,kb,kc,kd;
float theta0;
float x0;
int16_t gx0;
float omega0;
float omega0Acc;
bool flgGyroCalib = false;
int cntGyroCalib;
int32_t gxAcc;
bool flgTick = false;
bool flg1st = true;
bool flg1stCtrl = true;
bool flg1stCtrl2 = true;
bool isControlOn = true;
int cntSafety = 0;
char txbuff[256];
//int fb;
float fb;
int lr;

/*
 * モータの制御
 */
void ctrl_motor(int ch, int val)
{
    static const int IN1[]={MOTOR_L_IN1, MOTOR_R_IN1};
    static const int IN2[]={MOTOR_L_IN2, MOTOR_R_IN2};
    static const int PWM[]={MOTOR_L_PWM, MOTOR_R_PWM};
    
    int l,r;
    int lpwm,rpwm,lin1,lin2,rin1,rin2;
    
    int pwm = abs(val);
    if(pwm<0) pwm = 0;
    if(pwm>255) pwm = 255;
    
    int in1,in2;
    if(val > 0){
        in1 = LOW;
        in2 = HIGH;
    }else if(val < 0){
        in1 = HIGH;
        in2 = LOW;
    }else{
        in1 = LOW;
        in2 = LOW;
        pwm = 0;
    }

    digitalWrite(IN1[ch], in1);
    digitalWrite(IN2[ch], in2);
    analogWrite(PWM[ch], pwm);
}

// 初期化
void setup() {
  
    // PWMの初期化
    analogWrite(MOTOR_L_PWM, 0);
    analogWrite(MOTOR_R_PWM, 0);
    analogWrite(LED_L_PWM,   0);
    analogWrite(LED_R_PWM,   0);
   
    // GPIOの初期化
    digitalWrite(MOTOR_L_IN1, LOW);
    digitalWrite(MOTOR_L_IN2, LOW);
    digitalWrite(MOTOR_R_IN1, LOW);
    digitalWrite(MOTOR_R_IN2, LOW);
    digitalWrite(LED_L_PWM,   LOW);
    digitalWrite(LED_R_PWM,   LOW);
    pinMode(MOTOR_L_IN1, OUTPUT);
    pinMode(MOTOR_L_IN2, OUTPUT);
    pinMode(MOTOR_R_IN1, OUTPUT);
    pinMode(MOTOR_R_IN2, OUTPUT);
    pinMode(LED_L_PWM,   OUTPUT);
    pinMode(LED_R_PWM,   OUTPUT);
    
    // join I2C bus (I2Cdev library doesn't do this automatically)
    Wire.begin();

    // initialize serial communication
    // (38400 chosen because it works as well at 8MHz as it does at 16MHz, but
    // it's really up to you depending on your project)
    //Serial.begin(38400);
    SerialCom_init();
    
    // initialize device
    //Serial.println("Initializing I2C devices...");
    accelgyro.initialize();

    // verify connection
    //Serial.println("Testing device connections...");
    //Serial.println(accelgyro.testConnection() ? "MPU6050 connection successful" : "MPU6050 connection failed");

    MsTimer2::set(10, tickHandler);
    MsTimer2::start();
    
    isControlOn = true;
    // configure Arduino LED for
//    pinMode(LED_PIN, OUTPUT);
    theta = 0;
    v = 0;
    x = 0;
    x0 = 0;
    fb = 0;
    lr = 0;
    flg1st = true;
    flg1stCtrl = true;
    flg1stCtrl2 = true;

    if(EEPROM.read(0) == 0xA5){
      read_parameter();
    }else{
        ka = 3.0;
        kb = 2.0;
        kc = 5.0;
        kd = 3.0;
        theta0 = 96;
        write_parameter();
    }
    
    Serial.println("time,theta,omega,x,v,a,b,c,d");
}

// byte⇔float変換用
union{
    unsigned char b[4];
    float f;
} bfConv;

// パラメータのEEPROM読み出し
void read_parameter()
{
    ka = (float)((signed short)((EEPROM.read(1)<<8) + EEPROM.read(2))) / 10.0;
    kb = (float)((signed short)((EEPROM.read(3)<<8) + EEPROM.read(4))) / 10.0;
    kc = (float)((signed short)((EEPROM.read(5)<<8) + EEPROM.read(6))) / 10.0;
    kd = (float)((signed short)((EEPROM.read(7)<<8) + EEPROM.read(8))) / 10.0;
    
    theta0 = (float)((signed short)((EEPROM.read(9)<<8) + EEPROM.read(10))) / 10.0;
    //theta0 = 92.0;
    
    //Serial.println(ka);
    //Serial.println(kb);
    //Serial.println(kc);
    //Serial.println(kd);
    //Serial.println(theta0);
    
    bfConv.b[0] = EEPROM.read(11);
    bfConv.b[1] = EEPROM.read(12);
    bfConv.b[2] = EEPROM.read(13);
    bfConv.b[3] = EEPROM.read(14);
    
    if( isnan( bfConv.f) ){
      omega0 = 0;
    }else{
      omega0 = bfConv.f;
    }
    //Serial.println(omega0);
    //gx0 = (signed short)((EEPROM.read(11)<<8) + EEPROM.read(12));
    //Serial.println(omega0);
}

// パラメータのEEPROM書き込み
void write_parameter()
{
    EEPROM.write(0, 0xA5);
    signed short sval;
    unsigned char hb,lb;
    sval = (signed short)(ka*10.0);
    hb = (unsigned char)(sval >> 8);
    lb = (unsigned char)(sval & 0xFF);
    EEPROM.write(1, hb);
    EEPROM.write(2, lb);
    
    sval = (signed short)(kb*10.0);
    hb = (unsigned char)(sval >> 8);
    lb = (unsigned char)(sval & 0xFF);
    EEPROM.write(3, hb);
    EEPROM.write(4, lb);
    
    sval = (signed short)(kc*10.0);
    hb = (unsigned char)(sval >> 8);
    lb = (unsigned char)(sval & 0xFF);
    EEPROM.write(5, hb);
    EEPROM.write(6, lb);
    
    sval = (signed short)(kd*10.0);
    hb = (unsigned char)(sval >> 8);
    lb = (unsigned char)(sval & 0xFF);
    EEPROM.write(7, hb);
    EEPROM.write(8, lb);
    
    sval = (signed short)(theta0*10.0);
    hb = (unsigned char)(sval >> 8);
    lb = (unsigned char)(sval & 0xFF);
    EEPROM.write(9, hb);
    EEPROM.write(10, lb);
    
    //hb = (unsigned char)(gx0 >> 8);
    //lb = (unsigned char)(gx0 & 0xFF);
    //EEPROM.write(11, hb);
    //EEPROM.write(12, lb);
    bfConv.f = omega0;
    EEPROM.write(11, bfConv.b[0]);
    EEPROM.write(12, bfConv.b[1]);
    EEPROM.write(13, bfConv.b[2]);
    EEPROM.write(14, bfConv.b[3]);
}

// メインループ
void loop() {
      int16_t ax, ay, az;
    int16_t gx, gy, gz;
    int motor_out;
    static int cnt10ms = 0;
    
  if(flgTick){
    flgTick = false;
    
    // read 6 axis sensor (accel & gyro)
    accelgyro.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);
    
    // ジャイロのキャリブ
    if(flgGyroCalib){
        if( (cntGyroCalib % 10 ) == 0 ){
            int cnt = cntGyroCalib / 10;
            if(cnt < 200){
                omega0 = (float)gx / 32768 * 250;
                omega0Acc += omega0;
                //Serial.print(omega0);
                //Serial.print(" ");
                //Serial.println(omega0Acc);

                //gxAcc += (int32_t)gx;
                //sprintf(txbuff, "gx = %d, gxAcc = %d\r\n", gx, gxAcc);
                //Serial.print(txbuff);
                
            }else{
                flgGyroCalib = false;

                omega0 = omega0Acc / 200;
                //Serial.print(omega0);
                //Serial.print(" ");
                //Serial.println(omega0Acc);
                
                bfConv.f = omega0;
                EEPROM.write(11, bfConv.b[0]);
                EEPROM.write(12, bfConv.b[1]);
                EEPROM.write(13, bfConv.b[2]);
                EEPROM.write(14, bfConv.b[3]);
                
                //gx0 = (int16_t)(gxAcc / 50);
                //unsigned char hb = (unsigned char)(gx0 >> 8);
                //unsigned char lb = (unsigned char)(gx0 & 0xFF);
                //EEPROM.write(11, hb);
                //EEPROM.write(12, lb);
                //sprintf(txbuff, "gx0 = %d, gxAcc = %d\r\n", gx0, gxAcc);
                //Serial.print(txbuff);
            }
        }
        cntGyroCalib++;
        return;
    }
    
    // accel
    theta_acc = atan2(ay, az) * 180 / M_PI;
    
    // gyro
    //omega = (float)(gx-gx0) / 32768 * 250;
    omega = (float)gx / 32768 * 250 - omega0;
    // theta_gyro += omega * 0.01;
    
    // complementary filter
    if(flg1st){
      flg1st = false;
      theta = theta_acc;
    }else{
      theta = (0.996)*(theta + omega * 0.01) + (0.004)*(theta_acc);
    }
    
    // control law
    float a,b,d,c;
    float d_motor_out;
    if(flg1stCtrl && (abs(theta - theta0) > 1)){
      a = 0;
      b = 0;
      c = 0;
      d = 0;
    }else{
      flg1stCtrl = false;
      a = ka * (theta - theta0);
      b = kb * omega;
      c = kc * ((x-x0) / 100);
      d = kd * (v / 100);
    }
    d_motor_out = a+b+c+d;//+fb;
    
    // limitter
    if(d_motor_out >  128) d_motor_out =  128;
    if(d_motor_out < -128) d_motor_out = -128;
    if(abs(d_motor_out) >= 128){
      cntSafety++;
      if(cntSafety>=500){
        cntSafety = 0;
        x = 0;
        x0 = 0;
        d_motor_out = 0;
      }
    }
    
    // v & x
    v = d_motor_out;// + fb;
    x += v / 500; // およそcm単位
    if(flg1stCtrl2 && (abs(theta - theta0) < 0.1)){
        flg1stCtrl2 = false;
        x = 0;
    }
    motor_out = (int)d_motor_out;
    
    // motor output & serial send
    if(!isControlOn){
      ctrl_motor(0, 0);
      ctrl_motor(1, 0);
      cnt10ms++;
      if(cnt10ms >= 10){
        cnt10ms = 0;
        // serial send
        sprintf(txbuff, "#d%04X%04X%04X%04X%04X%04X$", t, (signed short)(theta*100),0,0,0,0);
        Serial.print(txbuff);
        //Serial.println(theta);
      }
    }else{
      ctrl_motor(0, motor_out + lr);
      ctrl_motor(1, motor_out - lr);
      cnt10ms++;
      if(cnt10ms >= 10){
        cnt10ms = 0;
        // serial send
        sprintf(txbuff, "#d%04X%04X%04X%04X%04X%04X$", t, (signed short)((theta - theta0)*100), (signed short)(omega*100), (signed short)(x*100), (signed short)(v*100), motor_out);
        Serial.print(txbuff);
        //Serial.println(theta);
      }
/*
      Serial.print(t); Serial.print(",\t");
      Serial.print(theta - theta0); Serial.print(",\t");
      Serial.print(omega); Serial.print(",\t");
      Serial.print(x); Serial.print(",\t");
      Serial.print(v); Serial.print(",\t");
      Serial.print(a); Serial.print(",\t");
      Serial.print(b); Serial.print(",\t");
      Serial.print(c); Serial.print(",\t");
      Serial.print(d); Serial.print(",\t");
      Serial.print("\n");
*/
    }
    // serial receive
    SerialCom_loop();
  }
}

// 10ms周期ハンドラ
void tickHandler() {
  flgTick = true;
  t += 10;
}

// シリアル受信コールバック
void SerialCom_callback(char* buff)
{
  int val;
  int ret;
  unsigned short uval;
  
  switch(buff[0])
  {
    // モード切替
    case 'm':
      // モードのトグル
      if(buff[1] == '\0'){
        isControlOn = !isControlOn;
      // 制御OFF
      }else if(buff[1] == '0'){
        isControlOn = false; 
      // 制御ON
      }else if(buff[1] == '1'){
        theta = 0;
        v = 0;
        x = 0;
        flg1st = true;
        flg1stCtrl = true;
        flg1stCtrl2 = true;
        isControlOn = true;
      }
      x = 0;
      break;
    // パラメータの表示(不使用)
    case 'p':
      Serial.print(ka); Serial.print("\t");
      Serial.print(kb); Serial.print("\t");
      Serial.print(kc); Serial.print("\t");
      Serial.print(kd); Serial.print("\t");
      Serial.print("\n");
      Serial.println(theta0);
      break;
    // K1の設定
    case 'a':
      ret = sscanf(&buff[1], "%d", &val);
      if(ret == 1){
        ka = (float)val;///10.0;
      }else{
        //Serial.println("BAD PARAMETER!");
      }
      //Serial.print("ka = ");
      //Serial.println(ka);
      break;
    // K2の設定
    case 'b':
      ret = sscanf(&buff[1], "%d", &val);
      if(ret == 1){
        kb = (float)val;///10.0;
      }else{
        //Serial.println("BAD PARAMETER!");
      }
      //Serial.print("kb = ");
      //Serial.println(kb);
      break;
    // K3の設定
    case 'c':
      ret = sscanf(&buff[1], "%d", &val);
      if(ret == 1){
        kc = (float)val;///10.0;
      }else{
        //Serial.println("BAD PARAMETER!");
      }
      //Serial.print("kc = ");
      //Serial.println(kc);
      break;
    // K4の設定
    case 'd':
      ret = sscanf(&buff[1], "%d", &val);
      if(ret == 1){
        kd = (float)val;///10.0;
      }else{
        //Serial.println("BAD PARAMETER!");
      }
      //Serial.print("kd = ");
      //Serial.println(kd);
      break;
    // θ0の設定
    case 't':
      ret = sscanf(&buff[1], "%d", &val);
      if(ret == 1){
        theta0 = (float)val/10.0;
      }else{
        //Serial.println("BAD PARAMETER!");
      }
      //Serial.print("theta0 = ");
      //Serial.println(theta0);
      break;
    // パラメータのセーブ
    case 's':
      write_parameter();
      break;
    // パラメータのリロードと送信
    case 'l':
      read_parameter();
      sprintf(txbuff, "#l%04X%04X%04X%04X%04X%02X$", (int)ka, (int)kb, (int)kc, (int)kd, (int)(theta0*10), (isControlOn ? 0x01:0x00));
      Serial.print(txbuff);
      break;
    // ジャイロのキャリブ
    case 'g':
      flgGyroCalib = true;
      cntGyroCalib = 0;
      gxAcc = 0;
      omega0Acc = 0;
      break;
    /* Dコマンド(前進/後退)
       書式: #Dxx$
       xx: 0のとき停止、正のとき前進、負のとき後退。
     */
    case 'D':
        // 値の解釈
        if( HexToUint16(&buff[1], &uval, 2) != 0 ) break;
        val = (int)((signed char)uval);
        fb = val / 8;
        x0 += val / 8;
        break;
        
    /* Tコマンド(旋回)
       書式: #Txx$
       xx: 0のとき中立、正のとき右旋回、負のとき左旋回
     */
    case 'T':
        // 値の解釈
        if( HexToUint16(&buff[1], &uval, 2) != 0 ) break;
        val = (int)((signed char)uval);
        lr = val / 8;
        break;
        
    default:
      //Serial.println("INVALID COMMAND!");
      ;
  }
}
