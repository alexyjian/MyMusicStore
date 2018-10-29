
window.onload = function () {
    
    var head_divs = document.getElementById('tab-head').getElementsByTagName('div');
    var current_index = 0;
    var timer = setInterval(autuCheck, 1000);
    for (var i = 0; i < head_divs.length; i++) {
        
        head_divs[i].onmouseover = function () {            
            clearInterval(timer);
            if (i != current_index) {
                head_divs[current_index].style.backgroundColor = '';
                head_divs[current_index].style.borderBottom = '';
            }
            var body_uls = document.getElementById('tab-body').getElementsByTagName('ul');
           
            for (var i = 0; i < body_uls.length; i++) {
                body_uls[i].className = body_uls[i].className.replace(' current', '');
                head_divs[i].className = head_divs[i].className.replace(' current', '');
                if (head_divs[i] == this) {
                    this.className += ' current';
                    body_uls[i].className += ' current';
                }
            }
        }
        head_divs[i].onmouseout = function () {
            timer = setInterval(autuCheck, 1000);
        }
    }
    function autuCheck() {
        ++current_index;
        if (current_index == head_divs.length)
            current_index = 0;
        for (var i = 0; i < head_divs.length; i++) {
            if (i == current_index) {
                head_divs[i].style.backgroundColor = '#fff';
                head_divs[i].style.borderBottom = '1px solid #fff';
            }
            else {
                head_divs[i].style.backgroundColor = '';
                head_divs[i].style.borderBottom = '';
            }
        }
        var body_uls = document.getElementById('tab-body').getElementsByTagName('ul');
        for (var i = 0; i < body_uls.length; i++) {
            body_uls[i].className = body_uls[i].className.replace(' current', '');
            head_divs[i].className = head_divs[i].className.replace(' current', '');
            if (head_divs[i] == head_divs[current_index]) {
                this.className += ' current';
                body_uls[i].className += ' current';
            }
        }
    }
}
