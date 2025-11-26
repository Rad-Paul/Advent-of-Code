let fourBitMap = new Map();
fourBitMap.set('0', '0000'); fourBitMap.set('1', '0001'); fourBitMap.set('2', '0010'); fourBitMap.set('3', '0011'); fourBitMap.set('4', '0100');
fourBitMap.set('5', '0101'); fourBitMap.set('6', '0110'); fourBitMap.set('7', '0111'); fourBitMap.set('8', '1000'); fourBitMap.set('9', '1001');
fourBitMap.set('A', '1010'); fourBitMap.set('B', '1011'); fourBitMap.set('C', '1100'); fourBitMap.set('D', '1101'); fourBitMap.set('E', '1110');
fourBitMap.set('F', '1111');

const fs = require('fs');

let input = fs.readFileSync('D:/coding/Personal/AdventOfCode/2021/Day-16/input.txt', 'utf-8');
Part1(input);
Part2(input);

function Part1(input){
    binary = getStringFromHex(input);
    let result = readPacket({index: 0}, binary, undefined, 0);
    console.log(result);
}
//Part1
function readPacket(pos, binary, packetEnd, versionTotal){
    if(pos.index >= binary.length){
        return;
    }
    if(packetEnd !== undefined && pos.index > packetEnd){
        return;
    }

    versionTotal += binaryToDecimal(binary.slice(pos.index, pos.index+3));
    pos.index += 3;
    let typeId = binaryToDecimal(binary.slice(pos.index, pos.index+3));
    pos.index += 3;

    if(typeId == 4){
        let binaryValue = getLiteralValue(pos);
    }else{
        readOperatorPacket(pos, packetEnd);
    }

    function getLiteralValue(pos){
        let value = [];
        let reading = true;
        while(reading){          
            if(binary[pos.index] == '0'){
                reading = false;
            }

            pos.index++;
            let chunk = binary.slice(pos.index, pos.index+4);
            value.push(chunk);
            pos.index+=4;
        }

        return value.join('');
    }
    function readOperatorPacket(pos, packetEnd){
        let lengthTypeId = binary[pos.index];
        pos.index++;

        if(lengthTypeId == '0'){
            let bitCountInBinary = binary.slice(pos.index, pos.index+15);
            pos.index += 15;
            let bits = binaryToDecimal(bitCountInBinary);
            let end = pos.index + bits;
            while(pos.index < end){
                versionTotal = readPacket(pos, binary, pos.index+bits, versionTotal);
            }
        }
        else if(lengthTypeId == '1'){
            let packetCountInBinary = binary.slice(pos.index, pos.index+11);
            pos.index += 11;
            let packets = binaryToDecimal(packetCountInBinary);
            while(packets > 0){
                versionTotal = readPacket(pos, binary, packetEnd, versionTotal);
                packets--;
            }
        }
    }
    //pos.index += 4-(pos.index % 4);

    return versionTotal;
}

function Part2(input){
    binary = getStringFromHex(input);
    let result = readPacket2({index: 0}, binary, undefined, 0);
    console.log(result);
}
//Part2 mostly the same, just separating them
function readPacket2(pos, binary, packetEnd, versionTotal){
    if(pos.index >= binary.length){
        return;
    }
    if(packetEnd !== undefined && pos.index > packetEnd){
        return;
    }
    let packetValues = [];
    versionTotal += binaryToDecimal(binary.slice(pos.index, pos.index+3));
    pos.index += 3;
    let typeId = binaryToDecimal(binary.slice(pos.index, pos.index+3));
    pos.index += 3;

    if(typeId == 4){
        packetValues.push(binaryToDecimal(getLiteralValue(pos)));
    }else{
        readOperatorPacket(pos, packetEnd);
    }

    function getLiteralValue(pos){
        let value = [];
        let reading = true;
        while(reading){          
            if(binary[pos.index] == '0'){
                reading = false;
            }

            pos.index++;
            let chunk = binary.slice(pos.index, pos.index+4);
            value.push(chunk);
            pos.index+=4;
        }

        return value.join('');
    }
    function readOperatorPacket(pos, packetEnd){
        let lengthTypeId = binary[pos.index];
        pos.index++;

        if(lengthTypeId == '0'){
            let bitCountInBinary = binary.slice(pos.index, pos.index+15);
            pos.index += 15;
            let bits = binaryToDecimal(bitCountInBinary);
            let end = pos.index + bits;
            while(pos.index < end){
                packetValues.push(readPacket2(pos, binary, pos.index+bits, versionTotal));
            }
        }
        else if(lengthTypeId == '1'){
            let packetCountInBinary = binary.slice(pos.index, pos.index+11);
            pos.index += 11;
            let packets = binaryToDecimal(packetCountInBinary);
            while(packets > 0){
                packetValues.push(readPacket2(pos, binary, packetEnd, versionTotal));
                packets--;
            }
        }
    }

    return evaluatePacketExpression(packetValues, typeId);
}
function evaluatePacketExpression(packets, typeId){
    if(packets.length == 1){
        return Number(packets[0]);
    }

    if(packets.length == 2){
        if(typeId == 5){
            return packets[0] > packets[1] ? 1 : 0;
        }
        if(typeId == 6){
            return packets[0] < packets[1] ? 1 : 0;
        }
        if(typeId == 7){
            return packets[0] == packets[1] ? 1 : 0;
        }
    }

    let operation = '';
    if(typeId == 0){
        operation = 'sum';
    }else if(typeId == 1){
        operation = 'product';
    }else if(typeId == 2){
        return Math.min(... packets);
    }else if(typeId == 3){
        return Math.max(... packets);
    }

    let toR = packets[0];
    for (let i = 1; i < packets.length; i++) {
        let value = packets[i];
        if(operation == 'sum'){
            toR += value;
        }else if(operation == 'product'){
            toR *= value;
        }
    }
    return toR;
}
function getStringFromHex(hexString){
    let toR = [];
    for (let i = 0; i < hexString.length; i++) {
        let char = hexString[i];
        toR.push(fourBitMap.get(char));
    }
    return toR.join('');
}
function hexCharToBinary(char){
    return fourBitMap.get(char);
}
function binaryToDecimal(binary){
    return parseInt(binary, 2);
}