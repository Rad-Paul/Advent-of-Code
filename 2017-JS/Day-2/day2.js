const fs = require('fs');

let input = fs.readFileSync('input.txt','utf-8').split('\r');
let lines = [];

for(let i = 0; i < input.length; i++){
    let line = input[i].split('\t');
    //line[line.length-1] = line[line.length - 1].slice(0, line[line.length-1].length - 1); if split by \n
    lines.push(line.map((element) => Number(element)));
}

Part1(lines);
Part2(lines);

function Part1(lines){
    let toR = 0;
    for(let i = 0; i < lines.length; i++){
        let numLine = lines[i];   
        let res = getDiffOfMaxAndMin(numLine);
        toR += res;
    }
    console.log(toR);
}
function Part2(lines){
    let result = 0;
    for(let i = 0; i < lines.length; i++){
        let divisorFound = false;
        let numLine = lines[i];
        for(let j = 0; j < numLine.length; j++){
            for(let k = 0; k < numLine.length; k++){
                if(k != j && numLine[j] % numLine[k] == 0){
                    divisorFound = true;
                    result += numLine[j] / numLine[k];
                }
                if(divisorFound){break;}
            }
            if(divisorFound){break;}
        }
        
    }
    console.log(result);
}

function getDiffOfMaxAndMin(input){
    //console.log(input);
    let min = 999999999;
    let max = -999999999;
    for(let i = 0; i < input.length; i++){
        let nr = input[i];
        if(nr < min){ min = nr;}
        if(nr > max){ max = nr;}
    }

    return max - min;
}