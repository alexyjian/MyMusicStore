//当页面加载时执行此方法
window.onload = function() {
    //获取所有的tab-head-div
    var head_divs = document.getElementById('tab-head').getElementsByTagName('div');
    //保存当前焦点元素的索引值
    var current_index = 0;
    //启动定时器
    var timer = setInterval(autuCheck, 5000);
    //遍历head元素
    for (var i = 0; i < head_divs.length; i++) {
        //添加鼠标悬停的事件
        head_divs[i].onmouseover = function() {
                clearInterval(timer);
                if (i != current_index) {
                    head_divs[current_index].style.backgroundColor = '';
                    head_divs[current_index].style.borderBottom = '';
                }
                //获取所有的tab-body-ul
                var body_uls = document.getElementById('tab-body').getElementsByTagName('ul');
                //遍历所有的tab-body-ul
                for (var i = 0; i < body_uls.length; i++) {
                    //将所有的元素隐藏 去掉current类名
                    body_uls[i].className = body_uls[i].className.replace(' current', '');
                    head_divs[i].className = head_divs[i].className.replace(' current', '');
                    //将当前索引对应的元素设为显示
                    if (head_divs[i] == this) {
                        this.className += ' current';
                        body_uls[i].className += ' current';
                    }
                }
            }
            //添加鼠标的移出事件
        head_divs[i].onmouseout = function() {
            timer = setInterval(autuCheck, 5000);
        }
    }
    //定义定时器，按周期tab栏的切换
    function autuCheck() {
        //每间隔对应周期 ，标签索引值自增
        ++current_index;
        //当索引值自增到上限 重置为0
        if (current_index == head_divs.length)
            current_index = 0;
        //切换标签后修改current标签的样式
        for (var i = 0; i < head_divs.length; i++) {
            if (i == current_index) {
                head_divs[i].style.backgroundColor = '#fff';
                head_divs[i].style.borderBottom = '1px solid #fff';
            } else {
                head_divs[i].style.backgroundColor = '';
                head_divs[i].style.borderBottom = '';
            }
        }
        //切换显示的内容
        //获取所有的tab-body-ul
        var body_uls = document.getElementById('tab-body').getElementsByTagName('ul');
        //遍历所有的tab-body-ul
        for (var i = 0; i < body_uls.length; i++) {
            //将所有的元素隐藏 去掉current类名
            body_uls[i].className = body_uls[i].className.replace(' current', '');
            head_divs[i].className = head_divs[i].className.replace(' current', '');
            //将当前索引对应的元素设为显示
            if (head_divs[i] == head_divs[current_index]) {
                this.className += ' current';
                body_uls[i].className += ' current';
            }
        }
    }
}