import 'dart:convert';
import 'dart:ffi';
import 'dart:io';

void main(){
  var file = File('./input.txt');
  List<String> lines = file.readAsStringSync(encoding: utf8).split('\r\n');
  part1(lines);
  part2(lines);
}

void part1(List<String> lines){
  List<String> toR = [];
  List<List<int>> grid = [[1,2,3], [4,5,6], [7,8,9]];
  int ci = 1, cj = 1;
  for(final line in lines){
    for(int i = 0; i < line.length; i++){
      if(line[i] == 'U'){
        if(ci-1 >= 0){ci = ci-1;}
      }else if(line[i] == 'R'){
        if(cj+1 < grid[0].length){cj = cj+1;}
      }else if(line[i] == 'D'){
        if(ci+1 < grid.length){ci = ci+1;}
      }else if(line[i] == 'L'){
        if(cj-1 >= 0){cj = cj-1;}
      }
    }
  toR.add(grid[ci][cj].toString());
  }
  print(toR.join());
}

void part2(List<String> lines){
  List<String> toR = [];
  List<List<String>> grid = [['-1', '-1', '1', '-1', '-1'], ['-1','2','3','4','-1'], ['5', '6','7', '8', '9'], ['-1', 'A', 'B', 'C', '-1'], ['-1','-1','D','-1','-1']];
  int ci = 2, cj = 0;
  for(final line in lines){
    for(int i = 0; i < line.length; i++){
      if(line[i] == 'U'){
        if(ci-1 >= 0 && grid[ci-1][cj] != '-1'){ci = ci-1;}
      }else if(line[i] == 'R'){
        if(cj+1 < grid[0].length && grid[ci][cj+1] != '-1'){cj = cj+1;}
      }else if(line[i] == 'D'){
        if(ci+1 < grid.length && grid[ci+1][cj] != '-1'){ci = ci+1;}
      }else if(line[i] == 'L'){
        if(cj-1 >= 0 && grid[ci][cj-1] != '-1'){cj = cj-1;}
      }
    }
  toR.add(grid[ci][cj]);
  }
  print(toR.join());
}