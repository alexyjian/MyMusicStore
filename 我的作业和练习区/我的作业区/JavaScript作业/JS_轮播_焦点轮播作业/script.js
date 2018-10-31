//页面加载完成时
window.onload = function () {
    var ul = document.getElementById('head_ul');
    var ul2 = document.getElementById('head_ul2');
    var ol = document.getElementById('head_ol');
    //取所有子元素
    var ollis = ol.children;
    //用来控制left
    var leader = 0;
    var target = 0;
    var leader1 = 576;
    var target2 = 0;
    //计算自动轮播页数
    var intr = 0;
    var intrs = 0;
    //计时器
    var timer = null;
    //遍历ol
    for (var i = 0; i < ollis.length; i++) {
        // 每个li的索引号
        ollis[i].index = i;
        //鼠标悬停事件
        ollis[i].onmouseover = function () {
            //清除计时器
            clearInterval(timer);
            for (var j = 0; j < ollis.length; j++) {
                ollis[j].className = '';//去掉所有的class='current'
            }
            //自动轮播页数同步
            intr = this.index;
            intrs = this.index;
            this.className = 'current';
            target = -this.index * 576;//目标位置=当前index索引号*图片宽度
        }
        ollis[i].onmouseout = function () {
            //重启计时器
            timer = setInterval(autoPlay, 3000);
        }
    }
    timer = setInterval(autoPlay, 3000);


    //过度动画
     tim= setInterval(function () {
        if (intr>6) {       
            ul.style.left = '0px';
            ul2.style.left = '576px';
            ul2.style.display = 'none';
            leader1 = 576;
            target2 = 0;
            leader = 0;
            target = 0;               
            intr=0;
            intrs=0;        
        } ;      
        
    }, 1);
    setInterval(function () {
        leader = leader + (target - leader) / 100;
        ul.style.left = leader + 'px';
        if (intr >5) {
            ul2.style.display = 'block';
            leader1 = leader1 + (target2 - leader1) / 100;
            ul2.style.left = leader1 + 'px';
            console.log(intr);
        }

    }, 2);

    function autoPlay() {
        intr++;
        intrs++;
        //目标位置=当前index索引号*图片宽度    
        target = -intr * 576;
        for (var j = 0; j < ollis.length; j++) {
            ollis[j].className = '';//去掉所有的class='current'
        }
        //当页数到达最大时重置
        if (intrs == ollis.length) {
            intrs = 0;     
        }       
        ollis[intrs].className = 'current';
    }
}