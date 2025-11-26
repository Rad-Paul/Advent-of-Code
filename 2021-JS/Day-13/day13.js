const fs = require('fs');

let data = fs.readFileSync('input.txt', 'utf-8').split('\r\n');
let commands = [];
let coords = [];
let toAdd = coords;
for(let i = 0; i < data.length; i++){
    if(data[i] == ''){
        toAdd = commands;
    }
    else{
        toAdd.push(data[i]);
    }
}

let paper = getMatrix(coords);

Part1(paper, commands);

function Part1(paper, commands){
    let toR = 0;
    for (let i = 0; i < commands.length; i++) {
        let command = commands[i].split('=');
        let direction = command[0];

        let index = command[1];
        direction = direction[direction.length - 1];

        let temp = [];
        if(direction == 'y'){
            let lineInd = paper.length - 1;
            for(let row = 0; row < index; row++){
                let l = [];
                let line = paper[lineInd];  
                for(let col = 0; col < paper[0].length; col++){
                    if(line[col] == '#'){
                        l.push('#');
                    }                        
                    else{
                        l.push(paper[row][col]);
                    }
                }
                temp.push(l);
                lineInd--;
            }
        }else{
            for(let row = 0; row < paper.length; row++){
                let colInd = paper[0].length - 1;
                let l = [];
                for(let col = 0; col < index; col++){
                    if(paper[row][colInd] == '#'){
                        l.push('#');
                    }
                    else{
                        l.push(paper[row][col]);
                    }
                    colInd--;
                }               
                temp.push(l);
            }
        }

        paper = temp;
        if(i == 0){
            toR = getVisibleCount(paper);
        }
        drawPaper(paper);
    }
    console.log('Part1 : ' + toR)
}

function getMatrix(coords){
    let width = -1;
    let height = -1;
    for(let i = 0; i < coords.length; i++){
        let coord = coords[i].split(',');
        if(Number(coord[0]) > width){
            width = Number(coord[0]);
        }
        if(Number(coord[1]) > height){
            height = Number(coord[1]);
        }
    }

    let matrix = [];
    for(let i = 0; i <= height; i++){
        matrix.push([]);
        for(let j = 0; j <= width; j++){
            matrix[i].push('.');
        }
    }

    for(let i = 0; i < coords.length; i++){
        let coord = coords[i].split(',');
        let x = Number(coord[0]);
        let y = Number(coord[1]);
        matrix[y][x] = '#';
    }
    
    return matrix;
}
function drawPaper(paper){
    for(let i = 0; i < paper.length; i++){
        let line = paper[i];
        let toShow = '';
        for(let j = 0; j < paper[i].length; j++){
            toShow += line[j];
        }
        console.log(toShow);
    }
    console.log(' ');
}
function getVisibleCount(paper){
    let count = 0;
    for (let i = 0; i < paper.length; i++) {
        let line = paper[i];
        for (let j = 0; j < paper[i].length; j++) {
            if(line[j] == '#'){
                count++;
            }
        }
    }
    return count;
}