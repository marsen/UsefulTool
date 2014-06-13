thisPage = {
    functions: {
        getRandom: function (min, max) {
            min = min || 1;
            max = max || 10;
            if (max > min) {
                return ~~(max * Math.random()) + min;
            } else {
                console.log("function RandomNum exception");
                return -1;
            }
        },
        getRandomColor: function() {
            return '#' + Math.random().toString(16).substr(-6);
        }        
    },
    methods: {
        getColorDiv: function() {
            var d = $.Deferred();
            $.ajax({
                url: "handler.ashx",
                async: false,
                cache: false,
                data: {
                    action: "test"
                },
                type: "post",
                dataType: "text"
            }).done(function () {
                var div = document.createElement('div');
                div.style.width = "10em";
                div.style.height = window.thisPage.functions.getRandom(5, 10) + "em";
                div.style.background = window.thisPage.functions.getRandomColor();
                document.getElementById("container").appendChild(div);
                console.log("done");
                d.resolve();
            }).error(function (a, b, c) {
                console.log('error');
                d.reject();
            });
            return d.promise();
        }
    }
};

(function () {
    var m = window.thisPage.methods,
        r = window.thisPage.functions.getRandom(20,30),
        defferreds = [];
    
    for (var i = 0; i < r; i++) {
        defferreds.push(m.getColorDiv());
    }
    $.when.apply($, defferreds).done(function () {
        console.log("DONE ALL");
    });
}());
