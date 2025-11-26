const fs = require('fs');

let data = fs.readFileSync('input.txt', 'utf-8').split('\r\n');
let input = [];
for(let i = 0; i < data.length; i++){
    let row = data[i].split('');
    input.push(row);
}

Part1(input);

function Part1(input){
    let result = 0;
    for(let steps = 0; steps < 1000; steps++){
        let map = new Map();
        for(let i = 0; i < input.length; i++){             
            for(let j = 0; j < input[0].length; j++){
                if(!map.has(i * 10 + j)){
                    input[i][j]++;
                    if(input[i][j] > 9){
                        result = flash(input, map, i, j, result+1);
                    }
                }
            }
        }
        if(steps == 99){
            console.log(`Part1 answer: ${result}`);
        }
        if(map.size == input.length * input[0].length){            
            console.log(`Part2 answer: ${steps}`);
            //drawMap(input);
            break;
        }  
    }
    
}
function Part2(){

}
function flash(input, map, i, j, result){
    map.set(i * 10 + j, true);
    input[i][j] = 0;
    //N
    if(i - 1 >= 0 && !map.has((i-1) * 10 + j)){
        input[i-1][j]++;
        if(input[i-1][j] > 9){
            result = flash(input, map, i-1, j, result + 1);
        }
    }
    //NE
    if(i - 1 >= 0 && j + 1 < input[0].length && !map.has((i-1) * 10 + j + 1)){
        input[i-1][j+1]++;
        if(input[i-1][j+1] > 9){
            result = flash(input, map, i-1, j+1, result + 1);
        }
    }
    //E
    if(j + 1 < input[0].length && !map.has(i * 10 + j + 1)){
        input[i][j+1]++;
        if(input[i][j+1] > 9){
            result = flash(input, map, i, j+1, result + 1);
        }
    }
    //SE
    if(i + 1 < input.length && j + 1 < input[0].length && !map.has((i+1) * 10 + j + 1)){
        input[i+1][j+1]++;
        if(input[i+1][j+1] > 9){
            result = flash(input, map, i+1, j+1, result + 1);
        }
    }
    //S
    if(i + 1 < input.length && !map.has((i + 1) * 10 + j)){
        input[i+1][j]++;
        if(input[i+1][j] > 9){
            result = flash(input, map, i+1, j, result + 1);
        }
    }
    //SW
    if(i + 1 < input.length && j - 1 >= 0 && !map.has((i+1) * 10 + j - 1)){
        input[i+1][j-1]++;
        if(input[i+1][j-1] > 9){
            result = flash(input, map, i+1, j-1, result + 1);
        }
    }
    //W
    if(j - 1 >= 0 && !map.has(i * 10 + j - 1)){
        input[i][j-1]++;
        if(input[i][j-1] > 9){
            result = flash(input, map, i, j-1, result + 1);
        }
    }
    //NW
    if(i - 1 >= 0 && j - 1 >= 0 && !map.has((i-1) * 10 + j - 1)){
        input[i-1][j-1]++;
        if(input[i-1][j-1] > 9){
            result = flash(input, map, i-1, j-1, result + 1);
        }
    }

    return result;
}
function drawMap(input){
    for(let i = 0; i < input.length; i++){
        let row = '';
        for(let j = 0; j < input[i].length; j++){
            row += input[i][j];
        }
        console.log(row);
    }
    console.log('');
}