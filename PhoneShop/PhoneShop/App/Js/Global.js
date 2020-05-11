function Ginit() {
	initNavBar();

	var navItems = document.getElementsByClassName('navBar')[0].getElementsByTagName('li');
	var navCell = document.getElementsByClassName('navBar_more');
	for (var i = 0; i < navItems.length; i++) {
		navItems[i].setAttribute('onmouseover', 'ShowMore(this)');
		navCell[i].setAttribute('onmouselddeave', 'CloseMore()');
	}
}

var navEle = null;


function ShowMore(ele) {
	CloseMore();
	navEle = ele;
	navEle.nextElementSibling.style.display = 'inline-block';
	navEle.style.fontSize = '24px';
}

function CloseMore() {
	if (navEle == null)
		return;
	navEle.nextElementSibling.style.display = 'none';
	navEle.style.fontSize = '20px';

}

function initNavBar() {
	var bar = $('#' + testItem[0].sid);
	for (var i = 0; i < 5; i++) {
		var brand = testItem[0].sid;
		var name = testItem[0].iname;
		var price = testType[0].price;
		var color = testColor[0].cid;
		bar.append(CreateNavCell(brand, name, price, color));
	}
}

function CreateNavCell(brand, name, price, color) {
	var div = document.createElement('div');
	div.setAttribute('class', 'nav_cell')
	div.setAttribute('id', brand + '-' + name);
	div.setAttribute('onclick', 'Jump(this)');

	var img = document.createElement('img');
	var path = '../Res/' + brand + '/' + name + '-' + color + '.jpg'
	img.setAttribute('src', path);

	var nameSpan = document.createElement('span');
	nameSpan.setAttribute('class', 'name');
	nameSpan.innerHTML = name;

	var priceSpan = document.createElement('span');
	priceSpan.setAttribute('class', 'price');
	priceSpan.innerHTML = '¥' + price;

	div.appendChild(img);
	div.appendChild(nameSpan);
	div.appendChild(priceSpan);

	return div;
}

function RegPhone(phone) {
	var reg = /^1[0-9]{10}$/;
	return reg.test(phone);
}

function RegPwd(pwd) {
	var reg = /^[0-9A-Za-z]{6,12}$/;
	return reg.test(pwd)
}





































var testColor = [{
	cid: "暗夜绿色",
	iid: 133
}, {
	cid: "金色",
	iid: 133
}, {
	cid: "银色",
	iid: 133
}];

var testItem = [{
	iid: 133,
	iname: "iPhone 11 Pro",
	intro: "全新三摄系统",
	istate: false,
	itime: "2020-05-04T00:00:00",
	sales: 0,
	sid: "apple"
}]

var testType = [{
	iid: 133,
	model: "2G+64G",
	price: 8699
}, {
	iid: 133,
	model: "2G+256G",
	price: 9999
}, {
	iid: 133,
	model: "2G+512G",
	price: 11799
}]
