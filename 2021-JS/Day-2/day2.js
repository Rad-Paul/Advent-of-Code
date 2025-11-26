const fs = require('fs');

let input = String(fs.readFileSync('D:\\coding\\Personal\\AdventOfCode\\2021\\Day-2\\input.txt', 'utf-8'));
let lines = input.split('\n');

Part1(lines);
Part2(lines);

function Part1(input){
    if(Array.isArray(input)){
        let depth = 0;
        let position = 0;
        for(let i = 0; i < input.length; i++){
            let line = input[i].split(' ');
            if(line[0] == "down"){
                depth += Number(line[1]);
            }
            else if(line[0] == "up"){
                depth -= Number(line[1]);
            }
            else if(line[0] == "forward"){
                position += Number(line[1]);
            }
        }
        console.log(position * depth);
    }
}
function Part2(input){
    if(Array.isArray(input)){
        let aim = 0;
        let depth = 0;
        let position = 0;
        for(let i = 0; i < input.length; i++){
            let line = input[i].split(' ');
            if(line[0] == "down"){
                aim += Number(line[1]);
            }
            else if(line[0] == "up"){
                aim -= Number(line[1]);
            }
            else if(line[0] == "forward"){
                position += Number(line[1]);
                depth += aim * Number(line[1]);
            }
        }

        console.log(position * depth);
    }
}