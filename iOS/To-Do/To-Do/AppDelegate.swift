program Eldevin_Farmer;
{$I SRL-OSR/SRL.simba}
// By MaxGreden
// ======= INSTRUCTIONS ===========
 //Move Camera as far up you can, so the angle is top-down
 //Camera Facing Directly North
 //Character in the middle of a crop field
 //Set Resolution 1024-600
 //Have inventory Open and keep it on the right side of the screen
 //Target Eldevin client
 //Chat Visible
 //Chat on 'General chat'

 //Only things required in Inventory is: Watercan(with water) and Seeds
 //Compost,Scarecrow, Dust is not required, but will use if found

  const
    CenterX = 510;
    CenterY = 296;
    InvX1 = 620;
    InvY1 = 0;
    InvX2 = 1020;
    InvY2 = 596;
  var
    WaitTime,Compost,Dust,Scarecrow,BasilSeed,WaterCan,x,y:Integer;

 Procedure LoadDTMs;
 begin
  Compost := DTMFromString('mlwAAAHicY2dgYGBhZmD4z8TA8BeKQXx2IOYB4gBGBoZoIA4FYh8gdgRidyD2BuIiP2sGK215hgD/AIbw8HCGskgXhl0ndjCUFJcwAI3BiRnxYCgAAAmlDYQ=');
  Scarecrow := DTMFromString('m6wAAAHic42ZgYLjKzMBwCYhvAPEVID4PxCeBeDcQPwLiD1C5y0Asx8jAwAnEXEAsBMSSQCwDxFJQGoTVgdgMiEOd1BgqU90ZqkqdGSrSQxn0TRUZypNdGTzCtRg681wZMmKDGNwsVRkcvTQZYICRyhgJAABwKRT2');
  BasilSeed := DTMFromString('mrAAAAHic42BgYHjKxMBwH4hvAPEtIL4DxI+B+BUQfwDijYwMDDuBeBsQrwfiVUC8HIhXA/EmIE6KimLwdHZm8HRyYgj29mZIjY4G84szMxmCvLwYgEoowjAAAJy6FG0=');
  Jute := DTMFromString('mbQAAAHicY2VgYOAGYiEgFgZiNgYIYAdiASBmhPL5gHjVqjqGsrIIhpAQR4aEBC8GLy9jBmyAEQsGAwBysAY3');
  Watercan := DTMFromString('mrAAAAHic42BgYHBnZmCwBmJzIHYGYh8gDgRiDyjtxwjBnkDsAsSuQOwFZfsCcWZxOcPKFSsZ2Nm5GNyi0hjSq9sZgoKCwOzk5GQGoBKKMAwAAKadDa0=');
  Dust := DTMFromString('mrAAAAHic42BgYHjKxMDwAIjvA/ErJggfJvYGiI8zMjBcBOJDQHwQiPcA8Q5GiPgxIN40z5yhNkmWISM9g+HMoX0MLS2tDGWRLgxLm6QYJk2cxEAIMBLAMAAAUhYZBQ==');
  wait(500);
 end;
Procedure CenterClick(DoubleClick: Boolean);
begin
 MoveMouse(CenterX,CenterY);
 ClickMouse(CenterX,CenterY, 1);
 if(DoubleClick)
 then
 begin
 wait(20);
 MoveMouse(CenterX,CenterY);
 ClickMouse(CenterX,CenterY, 1);
 end;
end;

Procedure E_Rake;
begin
writeln('Started program - Raking...');
wait(100);
  CenterClick(true);
end;
Procedure E_Compost;
begin
if FindDTM(Compost, x, y, InvX1, InvY1, InvX2, InvY2) then
begin
  writeln('Found Compost');
  MoveMouse(x,y);
 ClickMouse(x,y, 1);
  wait(100);
  CenterClick(false);
  writeln('Applying Compost...');
  wait(9000);
  end;
end;
Procedure E_Dust;
begin
if FindDTM(Dust, x, y, InvX1, InvY1, InvX2, InvY2) then
begin
  writeln('Found Dust');
  MoveMouse(x,y);
 ClickMouse(x,y, 1);
  wait(100);
  CenterClick(false);
  writeln('Applying Dust...');
  wait(9000);
  end;
end;
Procedure E_Scarecrow;
begin
  if FindDTM(Scarecrow, x, y, InvX1, InvY1, InvX2, InvY2) then
begin
  writeln('Found Scarescrow');
  MoveMouse(x,y);
 ClickMouse(x,y, 1);
  wait(100);
  CenterClick(false);
  writeln('Applying Scarecrow...');
  wait(5000);
  end;
end;
Procedure E_Seeds(seedDMT:Integer);
begin
  if FindDTM(seedDMT, x, y, InvX1, InvY1, InvX2, InvY2) then
begin
  writeln('Found Seed');
  MoveMouse(x,y);
 ClickMouse(x,y, 1);
  wait(100);
  CenterClick(false);
  writeln('Planting Seeds...');
  end else
  begin
   writeln('Could not find Seeds - Stopping program...');
  Exit;
  end;
end;
Procedure E_Water;
begin
  if FindDTM(Watercan, x, y, InvX1, InvY1, InvX2, InvY2) then
begin
  writeln('Found Watercan');
  MoveMouse(x,y);
 ClickMouse(x,y, 1);
  wait(100);
  CenterClick(false);
  writeln('Watering Seeds...');
  end else
  begin
   writeln('Could not find Watercan - Stopping program...');
  Exit;
  end;
end;
Procedure E_Spam;
begin
  writeln('Spamming leftClick');
  repeat
  wait(700);
   CenterClick(true);
   If FindColorTolerance(x,y,1074175,24,436,290,521, 1) Then  //finds color organge in Chat box / Looks for "Farming +X experience [x/]." / Finished Harvesting
   Begin
     WaitTime := 100;
     writeln('Harvested successfully - Restarting program');
   end;
   until(WaitTime = 100);
end;


//Main program
begin
LoadDTMs;
repeat
WaitTime := 0;
wait(1000);
E_Rake;
wait(9000);
E_Compost;
Wait(200);
E_Dust;
wait(200);
E_Scarecrow;
wait(200);
E_Seeds(Jute);     //<<-- what seed to be used
wait(6000);
E_Water;
wait(6000);
E_Spam;
until(false);
end.