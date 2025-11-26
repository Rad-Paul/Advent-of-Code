const fs = require('fs');

let input = fs.readFileSync('./input.txt', 'utf-8');
let processedInput = separateInput(input, '\r\n');

let visited = [];
for (let i = 0; i < input[0].length*5; i++) {
    let line = [];
    for (let j = 0; j < input.length*5; j++) {
        line[j] = false;
    }
    visited.push(line);
}

Part1(processedInput);
Part2(processedInput);

function Part1(input){
    let visited = new Map();
    let start = {i: 0, j: 0};

    let queue = [start];
    visited.set(getKey(0,0), 0);

    while(queue.length > 0){
        queue.sort((a,b) => visited.get(getKey(a.i, a.j)) - visited.get(getKey(b.i,b.j)));
        let current = queue.shift();
        let i = current.i; let j = current.j;
        let currentKey = getKey(i,j);

        if(i == input.length-1 && j == input.length-1){
            console.log(visited.get(currentKey));
            break;
        }

        let currentDist = visited.get(currentKey);

        let directions = [[i-1,j],[i,j+1],[i+1,j],[i,j-1]];
        for (let i = 0; i < directions.length; i++) {
            let ni = directions[i][0]; let nj = directions[i][1];
            if(ni != input.length && ni > -1 && nj != input.length && nj > -1){
                let neighbourKey = getKey(ni, nj);
                if(!visited.has(neighbourKey)){
                    visited.set(neighbourKey, currentDist + Number(input[ni][nj]));
                    queue.push({i: ni, j: nj});
                }else{
                    let newDist = currentDist + Number(input[ni][nj]);
                    if(newDist < visited.get(neighbourKey)){
                        visited.set(neighbourKey, newDist);
                        //queue.push({i: ni, j: nj});
                    }
                }
            }
        }
    }
    //console.log(visited.get(getKey(input.length-1, input.length-1)));
}

function Part2(input){
    //takes about 25s, not great, not terrible
    let visited = new Map();
    let start = {i: 0, j: 0};

    let queue = [start];
    visited.set(getKey(0,0), 0);
    let n = input.length * 5;
    while(queue.length > 0){
        queue.sort((a,b) => visited.get(getKey(a.i, a.j)) - visited.get(getKey(b.i,b.j)));
        let current = queue.shift();
        let i = current.i; let j = current.j;
        let currentKey = getKey(i,j);

        if(i == input.length*5-1 && j == input.length*5-1){
            console.log(visited.get(currentKey));
            break;
        }

        let currentDist = visited.get(currentKey);

        let directions = [[i-1,j],[i,j+1],[i+1,j],[i,j-1]];
        for (let i = 0; i < directions.length; i++) {
            let ni = directions[i][0]; let nj = directions[i][1];
            if(ni != n && ni > -1 && nj != n && nj > -1){
                let neighbourKey = getKey(ni, nj);
                if(!visited.has(neighbourKey)){
                    visited.set(neighbourKey, currentDist + getNewCost(ni, nj, input));
                    queue.push({i: ni, j: nj});
                }else{
                    let newDist = currentDist + getNewCost(ni, nj, input);
                    if(newDist < visited.get(neighbourKey)){
                        visited.set(neighbourKey, newDist);
                        queue.push({i: ni, j: nj});
                    }
                }
            }
        }
    }

    //console.log(visited.get(getKey(input.length*5-1, input.length*5-1)));
}
function getKey(i, j){
    return String(i) + '-' + String(j);
}
function getNewCost(i, j, input){
    let n = input.length;
    let val = Number(input[i%n][j%n]) + Math.floor(i / n) + Math.floor(j / n) - 1;
    return (val % 9) + 1;
}
function separateInput(rawInput, separator){
    return rawInput.split(separator);
}