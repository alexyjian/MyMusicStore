var store = document.getElementById('MyStore');
var store_none = document.getElementById('store_none');
store.onmouseover = function () {
    store_none.style.display = 'block';
}
store.onmouseout = function () {
    store_none.style.display ='none';
}