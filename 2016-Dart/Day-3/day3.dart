import 'dart:convert';
import 'dart:io';

void main(){
  var file = File('./input.txt');
  List<String> lines = file.readAsStringSync(encoding: utf8).split('\r\n');

  part1(lines);
  part2(lines);
}

void part1(List<String> lines){
  int validTriangles = 0;
  for(final line in lines){
    List<int> sides = getSidesH(line);
    int s1 = sides[0]; int s2 = sides[1]; int s3 = sides[2];
    if(s1 + s2 > s3 && s1 + s3 > s2 && s2 + s3 > s1){
      validTriangles++;
    }
  }
  print(validTriangles);
}

List<int> getSidesH(String line){
  List<int> toR = [];
  for(int i = 0; i < 3; i++){
    String side = line[i*5 + 0 + 2] + line[i*5 + 1 + 2] + line[i*5 + 2 + 2];
    toR.add(int.parse(side.trim()));
  }
  return toR;
}

void part2(List<String> lines){
  int validTriangles = 0;
  for(int i = 0; i < lines.length; i+=3){
    List<List<int>> triangles = getSidesV([lines[i], lines[i+1], lines[i+2]]);
    for(int t = 0; t < triangles.length; t++){
      List<int> sides = triangles[t];
      int s1 = sides[0]; int s2 = sides[1]; int s3 = sides[2];
      if(s1 + s2 > s3 && s1 + s3 > s2 && s2 + s3 > s1){
        validTriangles++;
      }
    }
  }
  
  print(validTriangles);
}

List<List<int>> getSidesV(List<String> lines){
  List<List<int>> toR = [[],[],[]];
  for(int col = 0; col < 3; col++){
    for(int row = 0; row < 3; row++){
      String side = lines[row][col*5 + 0 + 2] + lines[row][col*5 + 1 + 2] + lines[row][col*5 + 2 + 2];
      toR[col].add(int.parse(side.trim()));
    }
  }
  return toR;
}