#include <Arduino.h>

const int ledDouble = 13;
const int buttonDouble = 12;
const int buttonScore3 = 11;
const int buttonReset = 10;
const int ledTriple = 9;
const int buttonTriple = 8;

int currentResetButtonState;
int currentScore3ButtonState;
int currentDoubleButtonState;
int currentTripleButtonState;
int lastResetButtonState;
int lastScore3ButtonState;
int lastDoubleButtonState;
int lastTripleButtonState;
int scoreTotalTrown;
int scoreAverage;
int timesTrown = 0;
int scoreRemaining;
int startScore = 501;
int score3 = 3;
int scoreTrown;

bool lightDoubleOn = false;
bool lightTripleOn = false;
bool finishAllowed = false;

void switchDoubleLightOn();
void resetGame();
void switchDoubleLightOff();
void switchTripleLightOn();
void switchTripleLightOff();
void trownMultiplier();
void doubleFinishCheck();
void scoreInput(int score);
void calculateAndDisplayStatistics();

void setup()
{
  Serial.begin(9600);
  pinMode(ledDouble, OUTPUT);
  pinMode(ledTriple, OUTPUT);
  pinMode(buttonTriple, INPUT);
  pinMode(buttonDouble, INPUT);
  pinMode(buttonScore3, INPUT);
  pinMode(buttonReset, INPUT);

  Serial.println("Let's play Darts!");
  scoreRemaining = startScore;
  Serial.println(scoreRemaining);
}

void loop()
{
  currentDoubleButtonState = digitalRead(buttonDouble);
  currentTripleButtonState = digitalRead(buttonTriple);
  currentResetButtonState = digitalRead(buttonReset);
  currentScore3ButtonState = digitalRead(buttonScore3);
  
 // if button is pressed keep track and change LED on/off
  if (lastDoubleButtonState == LOW && currentDoubleButtonState == HIGH)
  {
    if (!lightDoubleOn)
    {
      switchDoubleLightOn();
    }
    else
    {
      switchDoubleLightOff();
    }

  }
  
  if (lastTripleButtonState == LOW && currentTripleButtonState == HIGH)
  {
    if (!lightTripleOn)
    {
      switchTripleLightOn();
    }
    else
    {
      switchTripleLightOff();
    }
  } 
  

  if (lastScore3ButtonState == LOW && currentScore3ButtonState == HIGH)
  {

    Serial.println("button 11 pressed");
    scoreInput(3);
  }


  if (lastResetButtonState == LOW && currentResetButtonState == HIGH)
  {
    Serial.println("button 10 pressed");
    resetGame();
  }
  
 lastDoubleButtonState = currentDoubleButtonState; 
 lastTripleButtonState = currentTripleButtonState;
 lastResetButtonState = currentResetButtonState;
 lastScore3ButtonState = currentScore3ButtonState;
}

// volgende stap project: display regelen
// display kan via windows forms met behulp van C#
// display kan ook via python met pigame
// volgende stap code: 3x input = 1worp

void switchDoubleLightOn()
{
  digitalWrite(ledDouble, HIGH);
  digitalWrite(ledTriple, LOW);
  lightDoubleOn = true;
  lightTripleOn = false;
  Serial.println("Light Double switched on");
  delay(100);
}

void resetGame()
{
  calculateAndDisplayStatistics();
  digitalWrite(13, HIGH);
  delay(500);
  digitalWrite(13, LOW);
  delay(500);
  digitalWrite(13, HIGH);
  delay(500);
  digitalWrite(13, LOW);
  scoreRemaining = startScore;
  timesTrown = 0;
  Serial.println("Game has been reset");
  Serial.println(scoreRemaining);
  delay(500);
}

void switchDoubleLightOff()
{
  digitalWrite(ledDouble, LOW);
  lightDoubleOn = false;
  Serial.println("Light Double switched off");
  delay(100);
}

void switchTripleLightOn()
{
  digitalWrite(ledTriple, HIGH);
  digitalWrite(ledDouble, LOW);
  lightDoubleOn = false;
  lightTripleOn = true;
  Serial.println("Light Triple switched on");
  delay(100);
}


void switchTripleLightOff()
{
  digitalWrite(ledTriple, LOW);
  lightTripleOn = false;
  Serial.println("Light Triple switched off");
  delay(100);
}

int trownMultiplier(int score) 
{
  if (lightDoubleOn)
    {
      switchDoubleLightOff();
      finishAllowed = true;
      return 2 * score;
    }
    else if (lightTripleOn)
    {
      switchTripleLightOff();
      return 3 * score;
    }
    else
    {
      return score;
    }
}

void doubleFinishCheck()
{
  if (finishAllowed == true && scoreRemaining-scoreTrown == 0)
  {
    Serial.println("Congratulations! You have won the game!");
    resetGame();
  }

  else if (scoreRemaining-scoreTrown < 6)
  {
    Serial.println("Bust! You have to end with a double");
    Serial.println(scoreRemaining);
  }

  else
  {
    scoreRemaining -= scoreTrown;
    Serial.println(scoreRemaining);
  }
  finishAllowed = false;
  scoreTrown = 0;
}

void scoreInput(int score)
{
timesTrown++;
scoreTrown = trownMultiplier(score);
doubleFinishCheck();
delay(100);
}

void calculateAndDisplayStatistics()
{
  if (timesTrown == 0)
  {
    Serial.println("Game was already ready...");
    Serial.println(scoreRemaining);
  }

  else{
  scoreTotalTrown = startScore - scoreRemaining;
  scoreAverage = scoreTotalTrown / timesTrown;
  Serial.println("Times Trown: ");
  Serial.println(timesTrown);
  Serial.println("Average Score Trown: ");
  Serial.println(scoreAverage);
  }
}