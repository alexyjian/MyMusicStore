var sc = document.getElementById('li_drop');
var xia = document.getElementById('ul_drop');
sc.onmouseover = function () {
    xia.style.display = 'block';
    sc.style.backgroundColor = 'white'
    xia.style.boxShadow = '0px 8px 8px 0px rgba(0,0,0,0.2)';
}
sc.onmouseout = function () {
    xia.style.display = 'none';
    sc.style.backgroundColor = 'rgb(247,247,247)';
}
xia.onmouseover = function () {
    xia.style.display = 'block';
    sc.style.backgroundColor = 'white';
}
xia.onmouseout = function () {
    xia.style.display = 'none';
    sc.style.backgroundColor = 'rgb(247,247,247)';
}