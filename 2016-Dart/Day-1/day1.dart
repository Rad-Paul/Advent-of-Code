import 'dart:convert';
import 'dart:math';
import 'dart:io';
void main(){
  var inputFile = File('./input.txt');
  List<String> content = inputFile.readAsStringSync(encoding: utf8).split(', ');
  part1(content);
  part2(content);
}

void part1(List<String> instructions){
  List<String> directions = ['N', 'E', 'S', 'W'];
  int dirInd = 0;
  var mainPos = {
    'x': 0,
    'y': 0
  };

  void move(String direction, int amount){
    if(direction == 'N'){
      mainPos['y'] = (mainPos['y'] ?? 0) + amount;
    }else if(direction == 'E'){
      mainPos['x'] = (mainPos['x'] ?? 0) + amount;
    }else if(direction == 'S'){
      mainPos['y'] = (mainPos['y'] ?? 0) - amount;
    }else if(direction == 'W'){
      mainPos['x'] = (mainPos['x'] ?? 0) - amount;
    }
  }

  for(final instruction in instructions){
    String turn = instruction[0];
    int distance = int.parse(instruction.substring(1, instruction.length));
    if(turn == 'L'){
      dirInd--;
    }else{
      dirInd++;
    }
    String direction = directions[(dirInd + directions.length) % directions.length];
    move(direction, distance);
  }

  print(mainPos['x']!.abs() + mainPos['y']!.abs());
}

void part2(List<String> instructions){
  List<String> directions = ['N', 'E', 'S', 'W'];
  int dirInd = 0;

  int part2Answer = 0;

  var mainPos = {
    'x': 0,
    'y': 0
  };
  Map positions = Map();

    void move2(String direction, int amount){
    //changed to loop for part 2
    List<int> values = [0, 0];
    if(direction == 'N'){
      values[1] = 1;
    }else if(direction == 'E'){
      values[0] = 1;
    }else if(direction == 'S'){
      values[1] = -1;
    }else if(direction == 'W'){
      values[0] = -1;
    }

    for(int i = 0; i < amount; i++){
      mainPos['y'] = mainPos['y']! + values[1];
      mainPos['x'] = mainPos['x']! + values[0];
      String posKey = mainPos['y']!.toString() + '/' + mainPos['x']!.toString();
      if(positions.containsKey(posKey) && part2Answer == 0){
      part2Answer = mainPos['x']!.abs() + mainPos['y']!.abs();
      }else{
      positions[posKey] = 0;
      }
    }
  }
  
  for(final instruction in instructions){
    String turn = instruction[0];
    int distance = int.parse(instruction.substring(1, instruction.length));
    if(turn == 'L'){
      dirInd--;
    }else{
      dirInd++;
    }
    String direction = directions[(dirInd + directions.length) % directions.length];
    move2(direction, distance);
  }

  print(part2Answer);
}