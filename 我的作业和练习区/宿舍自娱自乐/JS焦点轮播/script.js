//页面加载时执行此方法
window.onload = function () {
    //获取文档所有head下所有img
    var imgs = document.getElementById('head').getElementsByTagName('img');
    //获取文档所有head下所有li
    var lis = document.getElementById('head').getElementsByTagName('li');
    //定义计时器
    var time = null;
    //计数
    var current_index = 0;

    //启动计时器
    time = setInterval(autuCheck, 3000);

    for (var i = 0; i < lis.length; i++) {
        lis[i].onmouseover = function () {
            //清除计时器
            clearInterval(time);
            //图片标码和当前标码不同时隐藏图片          
            if (i != current_index) {
                imgs[current_index].style.display = 'none';
            }

            for (var i = 0; i < imgs.length; i++) {
                if (lis[i] == this) {
                    imgs[i].style.display = 'block';
                    lis[i].style.backgroundColor = 'rgb(70, 64, 64)';
                }
                else {
                    imgs[i].style.display = 'none';
                    lis[i].style.backgroundColor = '#ccc';
                }
            }
        }
        //鼠标移出当前时启动计时器
        lis[i].onmouseout = function () {
            time = setInterval(autuCheck, 3000);
        }
    }

    //图片轮播
    function autuCheck() {
        current_index++;
        if (current_index == imgs.length)
            current_index = 0;
        for (var i = 0; i < imgs.length; i++) {
            if (i == current_index) {
                imgs[i].style.display = 'block';
                lis[i].style.backgroundColor = 'rgb(70, 64, 64)';
            }
            else {
                imgs[i].style.display = 'none';
                lis[i].style.backgroundColor = '#ccc';
            }
        }
    }

}
