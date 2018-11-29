var oImg = $('img');
var len = oImg.length;
var flag = true;
var curDisplay = 0;
var nowIndex = 0;
var timer;
var wrap = $('.wrapper');
var btn = $('.btn');

function init() {
    carousel();
    bindEvent();
}
init();

function carousel() {
    var midLen = Math.floor(len / 2);
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
    oImg.eq(curDisplay).css({
        transform: 'translateZ(300px)'
    });
    wrap.on('transitionend', function () {
        flag = true;
    })
}

function bindEvent() {
    oImg.on('click', function (e) {
        if (flag) {
            flag = false;
            nowIndex = $(this).index();
            moving(nowIndex);
        }
    }).hover(function () {
        clearInterval(timer);
    }, function () {
        timer = setInterval(function () {
            play();
        }, 3000);
    });
    timer = setInterval(function () {
        play();

    }, 3000);

    btn.on('click', function () {
        if (flag) {
            flag = false;
            var dir = $(this).attr('id');
            if (dir == 'left') {
                nowIndex = nowIndex - 1;
            } else {
                nowIndex = nowIndex + 1;
            }
            moving(nowIndex);
        }
    }).hover(function () {
        clearInterval(timer);
    }, function () {
        timer = setInterval(function () {
            play();
        }, 3000);
    });
}

function play() {
    if (nowIndex == len - 1) {
        nowIndex = 0;
    } else {
        nowIndex++;
    }
    moving(nowIndex);
}

function moving(index) {
    index = index < 0 ? len - 1 : index;
    index = index > len - 1 ? 0 : index;
    curDisplay = index;
    nowIndex = index;
    carousel();
}

