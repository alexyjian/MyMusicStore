var oImg = $('img');//选出图片标签
var len = oImg.length;//保存有几张图片
var flag = true;//判断是否翻页
var nowIndex = 0; //保存图片索引
var timer; //弄一个定时器
var wrap = $('.wrapper');//保存最大的DIV
var btn = $('.btn');//保存左右按钮

function init() {
    carousel();
    bindEvent();
}
init();
//代码旋转
function carousel() {
    var midLen = Math.floor(len / 2); //每边一半的图片数量
    var lNum, rNum; //保存左右图片的位置
    for (var i = 0; i < midLen; i++) {
        lNum = nowIndex - i - 1; //从中间数 获取左边从第一张开始的图片
        oImg.eq(lNum).css({
            transform: 'translateX(' + (-150 * (i + 1)) + 'px) translateZ(' + (200 - i * 100) + 'px)'
        })
        rNum = nowIndex + i + 1;//从中间数 获取从右边第一张开始的图片
        if (rNum > len - 1) {
            rNum -= len;
        }
        oImg.eq(rNum).css({
            transform: 'translateX(' + (150 * (i + 1)) + 'px) translateZ(' + (200 - i * 100) + 'px)'
        });
    };
    oImg.eq(nowIndex).css({
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

