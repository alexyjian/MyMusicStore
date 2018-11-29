var oImg = $('img');
var len = oImg.lenght;
function carousel(){
    var midLen =  Math.floor(len/2);
    var lNum, rNum;
    for (var i = 0; i < midLen; i++) {
        lNum = curDisplay - i - 1;
        oImg.eq(lNum).css({
            transform: 'translateX(' + (-150 * (i + 1)) + 'px) translateZ(' + (200 - i * 100) + 'px)'
        })
        rNum = curDisplay + i + 1;
        if (rNum > len - 1) {
            rNum -= len;
        }
        oImg.eq(rNum).css({
            transform: 'translateX(' + (150 * (i + 1)) + 'px) translateZ(' + (200 - i * 100) + 'px)'
        });
    };

}
carousel();