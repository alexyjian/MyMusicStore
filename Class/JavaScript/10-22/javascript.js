var li01 = document.getElementById('store');
var li02 = document.getElementById('storeList');
li01.onmouseover = function() {
    li01.style.backgroundColor = "white";
    li01.style.border = "1px 1px 0px 1px solid #eee";
    li01.style.borderRadius = "2px 2px 0px 0px";
    li02.style.display="block";
}

li01.onmouseout = function() {
    li01.style.backgroundColor = "#f5f5f5";
    li01.style.border = "none";
    li01.style.borderRadius = "0px";
    li02.style.display="none";
}