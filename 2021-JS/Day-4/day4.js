const fs = require('fs');

let data = fs.readFileSync('input.txt', 'utf-8');
let split = data.split('\n');
numbers = split[0].split(',');

let boards = getBingoBoards(split);
//console.log(boards);

console.log(Part1(boards, numbers));
console.log(Part2(boards, numbers));

function Part1(boards, numbers){
    for(let i = 0; i < numbers.length; i++){
        for(let j = 0; j < boards.length; j++){
            markBoard(boards[j], numbers[i]);
            if(isBingo(boards[j])){
                return numbers[i] * getBoardScore(boards[j]);
            }
        }    
        //console.log(numbers[i]);
    }
}
function Part2(boards, numbers){
    let winningBoards = Array.from({length: boards.length}, () => false);
 
    for(let i = 0; i < numbers.length; i++){
        for(let j = 0; j < boards.length; j++){
            markBoard(boards[j], numbers[i]);
            if(isBingo(boards[j])){
                let lastBoard = true;
                winningBoards[j] = true;
                for(let k = 0; k < winningBoards.length; k++){
                    if(winningBoards[k] == false){
                        lastBoard = false;
                        break;
                    }                   
                }
                if(lastBoard){
                    return numbers[i] * getBoardScore(boards[j]);
                }
            }
        }    
        //console.log(numbers[i]);
    }
}
function markBoard(board, num){
    for(let i = 0; i < board.length; i++){
        let line = board[i];
        for(let j = 0; j < line.length; j++){
            if(num == line[j].value){
                line[j].found = true;
            }
        }
    }
}
function isBingo(board){
    for(let i = 0; i < board.length; i++){
        win = true;
        let line = board[i];
        for(let j = 0; j < line.length; j++){
            if(line[j].found == true){
                continue;
            }else{
                win = false;
                break;
            }
        }
        if(win == true){
            return true;
        }
        win = true;
        for(let j = 0; j < board.length; j++){
            let row = board[j];
            if(row[i].found == true){
                continue;
            }else{
                win = false
                break;
            }
        }
        if(win == true){
            return true;
        }
    }
}
function getBoardScore(board){
    let sum = 0;
    for(let i = 0; i < board.length; i++){
        let line = board[i];
        for(let j = 0; j < line.length; j++){
            if(line[j].found == false){
                sum += line[j].value;
            }
        }
    }
    return sum;
}
function getBingoBoards(split){
    let boards = [];
    let boardInd = 0;
    //split.forEach(element => {
    //console.log(element + '' + element.length);
    //});
    let board = [];
    for(let i = 1; i < split.length; i++){
        let line = split[i];
        if(line.length == 0){
            if(board.length > 0){
                boards.push(board);
            }
            board = [];
            boardInd = 0;
        }
        else{
            let splitLine = line.split(' ');
            board[boardInd] = [];
            for(let j = 0; j < splitLine.length; j++){
                if(splitLine[j] !== ''){
                    let num = Number(splitLine[j]);
                    board[boardInd].push({value: num, found: false});
                }
            }
            boardInd++;
        }
    }
    if(board.length > 0){
        boards.push(board);
    }

    return boards;
}
