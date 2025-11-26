const fs = require('fs');

let data = fs.readFileSync('input.txt', 'utf-8').split('\r\n');
let map = new Map();
let start = data[0];
for(let i = 2; i < data.length; i++){
    let pair = data[i].split(' -> ');
    map.set(pair[0], pair[1]);
}

Part1(start, map);
Part2(start,map);

function Part2(start, map){
    let elementMap = new Map();
    let charMap = new Map();

    for(let i = 0; i < start.length-1; i++){
        let element = start[i] + start[i+1];
        if(map.has(element)){
            if(elementMap.has(element)){
                elementMap.set(element, elementMap.get(element)+1);
            }else{
                elementMap.set(element, 1);
            }
        }
    }
    for(let i = 0; i < start.length; i++){
        if(charMap.has(start[i])){
            charMap.set(start[i], charMap.get(start[i])+1);
        }else{
            charMap.set(start[i], 1);
        }
    }

    for(let i = 0; i < 40; i++){
        let nextMap = new Map();
        for(let key of elementMap.keys()){
            let newEl = map.get(key);
            let newPair = key[0] + newEl;
            if(nextMap.has(newPair)){
                nextMap.set(newPair, elementMap.get(key) + nextMap.get(newPair));
            }else{
                nextMap.set(newPair, elementMap.get(key));
            }

            let otherPair = newEl + key[1];
            if(nextMap.has(otherPair)){
                nextMap.set(otherPair, elementMap.get(key) + nextMap.get(otherPair));
            }else{
                nextMap.set(otherPair, elementMap.get(key));
            }
            
            if(charMap.has(newEl)){
                charMap.set(newEl, charMap.get(newEl) + elementMap.get(key));
            }else{
                charMap.set(newEl, 1);
            }
        }
        elementMap = nextMap;
    }
    let values = Array.from(charMap.values());
    values.sort((a,b) => b-a);
    console.log(values[0] - values[values.length-1]);
}
function Part1(start, map){
    console.log(start);
    for (let i = 0; i < 10; i++) {
        let next = [];
        next.push(start[0]);
        for(let j = 0; j < start.length-1; j++){
            let current = start[j] + start[j+1];
            if(map.has(current)){
                next.push(map.get(current));
            }
            next.push(current[1]);
        }
        //console.log(next.join(''));
        start = next;
    }
    //console.log(start.join(''));
    getP1Result(start);
}
function getP1Result(array){
    let frequencyMap = new Map();
    for(let i = 0; i < array.length; i++){
        if(frequencyMap.has(array[i])){
            frequencyMap.set(array[i], frequencyMap.get(array[i])+1);
        }else{
            frequencyMap.set(array[i], 1);
        }
    }
    let values = Array.from(frequencyMap.values());
    values.sort((a,b) => b-a);
    console.log(values[0] - values[values.length-1]);
}