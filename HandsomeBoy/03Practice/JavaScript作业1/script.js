
    // 我自己的写法
    // var store = document.getElementById('store');
    // var store_none = document.getElementById('store_none');
    // store.onmouseover = function () {
    //     store_none.style.display = 'block';
    // }
    // store.onmouseout = function () {
    //     store_none.style.display ='none';
    // }


    //老师的写法
    // <li class="ul_right" onmouseover="change('ul_right','block')" onmouseout="change('ul_right','none')">

    //id传入的控件id，mode变换的属性值
    function change(id,mode)
    {
        document.getElementById(id).style.display=mode;

        if(mode=='block')
        {
            //设置下拉菜单边框
            document.getElementById(id).style.border='1px solid #eee';
            document.getElementById(id).style.borderTop='none';
        //设置显示下拉菜单时，鼠标滑过li的效果
        document.getElementById(id).parentNode.style.backgrouneColor='#fff';
        document.getElementById(id).parentNode.style.border='1px solid #eee';
        document.getElementById(id).parentNode.style.borderBottom='none';
        }
        else
        {
            document.getElementById(id).parentNode.style.backgrouneColor='';   
            document.getElementById(id).parentNode.style.border='';
        }
    }