const fs = require('fs');
const { off } = require('process');

let input = fs.readFileSync('input.txt','utf-8').split('\n');
let lines = [];
for(let i = 0; i < input.length; i++){
    let line = input[i].split(' ');
    if(i != input.length-1){
        line[line.length-1] = line[line.length-1].slice(0, line[line.length-1].length - 1);
    }
    lines.push(line);
}

Part1(lines);
Part2(lines);
function Part1(lines){
    let total = 0;
    for(let i = 0; i < lines.length; i++){
        let map = new Map();
        let toCount = 1;
        let line = lines[i];
        for(let j = 0; j < line.length; j++){
            if(!map.has(line[j])){
                map.set(line[j], 1);
            }else{
                toCount = 0;
                break;
            }
        }
        total += toCount;
    }
    console.log(total);
}
function Part2(lines){
    let total = 0;
    for(let i = 0; i < lines.length; i++){
        let map = new Map();
        let toCount = 1;
        let line = lines[i];
        for(let j = 0; j < line.length; j++){
            if(!map.has(line[j])){                
                let word = line[j];
                let letterMap = new Map();
                for(let k = 0; k < word.length; k++){
                    if(!letterMap.has(word[k])){
                        letterMap.set(word[k], 1);
                    }else{
                        letterMap.set(word[k], letterMap.get(word[k]) + 1);
                    }
                }
                //console.log(letterMap);
                let isAnagram = false;
                for(let [key,value] of map){            
                    if(key.length == word.length && !isAnagram){
                        let otherMap = value;
                        for(let [charKey,charValue] of otherMap){
                            //console.log(`Key:${charKey} Value:${charValue}`)
                            if(letterMap.has(charKey) && letterMap.get(charKey) == charValue){
                                isAnagram = true;
                            }else{
                                isAnagram = false;
                                break;
                            }
                        }
                    }
                }
                if(isAnagram == true){
                    toCount = 0;
                    break;
                }

                map.set(line[j], letterMap);                
            }else{
                toCount = 0;
                break;
            }
        }
        total += toCount;
    }
    console.log(total);
}