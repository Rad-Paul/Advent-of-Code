const fs = require('fs');

let data = fs.readFileSync('input.txt','utf-8').split('\n');

Part1(data);

function Part1(data){

    let digitSegCounts = new Map();
    digitSegCounts.set(2, 1);
    digitSegCounts.set(4, 4);
    digitSegCounts.set(3, 7); 
    digitSegCounts.set(7, 8); 
    
    let count = 0;
    for(let i = 0; i < data.length; i++){
        let split = data[i].split(' | ');
        let signalPatterns = split[0].split(' ');
        let outputValues = split[1].split(' ');
        if(i != data.length - 1){
            outputValues[outputValues.length - 1] = outputValues[outputValues.length - 1].slice(0, outputValues[outputValues.length-1].length - 1);
        }

        let found = [];
        for(let j = 0; j < signalPatterns.length; j++){
            if(digitSegCounts.has(signalPatterns[j].length)){
                for(let k = 0; k < outputValues.length; k++){
                    if(outputValues[k].length == signalPatterns[j].length && !found[k]){
                        found[k] = true;
                        count++;
                    }
                }
            }
        }
        console.log(count);
    }

    console.log(count);
}
function Part2(data){
    
}