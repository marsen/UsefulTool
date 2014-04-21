﻿HTMLElement.prototype.Pager = Pager;
//var p = new Pager({ count: 48, range: 2, page: 3 });
document.getElementById("pager").Pager({ count: 48, range: 2, page: 3 });
//test area 

function Pager(obj) {
    var template = {},
        me = this;
    obj = obj || { count: 0, range: 2, page: 3 };
    (function init() {
        getTemplate(pagerLayout);
    }());
    function getTemplate(func) {
        //ajax
        try {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4) {
                    var resp = xhr.responseText;
                    // resp now has the text and you can process it.
                    var dom = new DOMParser().parseFromString(resp, "text/xml");
                    template.firstPage = dom.getElementById("page.first.html").innerHTML,
                    template.previousPage = dom.getElementById("page.previous.html").innerHTML,
                    template.otherPage = dom.getElementById("page.html").innerHTML,
                    template.currentPage = dom.getElementById("page.current.html").innerHTML,
                    template.nextPage = dom.getElementById("page.next.html").innerHTML,
                    template.lastPage = dom.getElementById("page.last.html").innerHTML;
                    func();
                } else {
                    //todo
                    //throw new Object({ message: 'getTemplate Error' });
                }
            };
            xhr.open("GET", "template/default.html", true);
            xhr.send();
        } catch (e) {
            //todo
            //throw new Object({ message: 'getTemplate Error' });
        } 

    }
    function pagerLayout() {
        var html = '',
            temp = '',
            firstPage = '',//document.getElementById("page.first.html").innerHTML,
            previousPage = '',//document.getElementById("page.previous.html").innerHTML,
            otherPage = '',//document.getElementById("page.html").innerHTML,
            currentPage = '',//document.getElementById("page.current.html").innerHTML,
            nextPage = '',//document.getElementById("page.next.html").innerHTML,
            lastPage = '',//document.getElementById("page.last.html").innerHTML,
            range = obj.range,
            count = obj.count,
            page = obj.page;

        //
        if (page > 1) {
            temp += template.firstPage;
            temp += template.previousPage;
        }
        var l = (page + range) + 1, i = ((page - range));
        for (i ; i < l; i++) {
            // 如果這是一個正確的頁數...
            if ((i > 0) && (i <= count)) {
                // 如果這一頁等於當前頁數...
                if (i == page) {
                    temp += template.currentPage;
                } else {
                    temp += template.otherPage.replace(/\{page\}/g, i);// 顯示連結
                } // end else
            } // end if
        }
        if (page < count) {
            temp += template.nextPage;
            temp += template.lastPage;
        }
        var item = {
            current: page,
            previous: page - 1,
            next: page + 1,
            last: count
        };
        html = compile(temp, item);
        //document.getElementById("pager").innerHTML = html;
        me.innerHTML = html;
    }
}

//將template中所有的 {***} 變數 取代成 data[***]
function compile(template, data) {
    return template.replace(/\{\s?([\w\s\.]*)\s?\}/g, function (str, key) {
        key = key.trim();
        var v = data[key];
        return (typeof v !== 'undefined' && v !== null) ? v : '';
    });
}

