$('#header').on('onmouseover', function(){ //绑定onmouseover 事件
    $('#right').css('display','block');  //显示右边子菜单
} );
$('#header').on('onmouseout', function(){ //绑定onmouseout 事件
    $('#right').css('display','none');  //鼠标移出后设置为隐藏
}