function showSubMenu(li){
    var subMenu = li.getElementsByTagName("ul")[0];                  /*传了一个参数li进来，表示当前鼠标经过的li，
                                                                     再通过查找当前li下面的第一个ul，注意数组从0开始*/
    subMenu.style.display = "block";
}