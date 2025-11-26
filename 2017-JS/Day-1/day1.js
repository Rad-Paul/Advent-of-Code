const fs = require('fs');

let data = fs.readFileSync('input.txt', 'utf-8');

Part1(data);
Part2(data);
function Part1(input){
    let toR = 0;
    for(let i = 0; i < input.length; i++){
        if(i == input.length-1){
            if(input[i] == input[0]){
                toR += Number(input[i]);
            }
        }

        if(input[i] == input[i+1]){
            toR += Number(input[i]);
        }
    }
    console.log(toR);
}

function Part2(input){
    let toR = 0;
    for(let i = 0; i < input.length/2; i++){
        if(input[i] == input[input.length/2 + i]){
            toR += Number(input[i]);
        }
    }
    for(let i = input.length/2; i < input.length; i++){
        if(input[i] == input[i - input.length/2]){
            toR += Number(input[i]);
        }
    }
    console.log(toR);
}