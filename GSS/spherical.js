'use strict';
var spherical = {

    sg: function (b, a) {
        var r = this.LatToRadians(b);
        b = this.LngToRadians(b);
        var d = this.LatToRadians(a);
        a = this.LngToRadians(a);
        return 2 * Math.asin(Math.sqrt(Math.pow(Math.sin((r - d) / 2), 2) + Math.cos(r) * Math.cos(d) * Math.pow(Math.sin((b - a) / 2), 2)));
    },
    computeDistanceBetween: function (a, b, order) {
        order = order || 6378137;
        return this.sg(a, b) * order;
    },
    computeLength: function (path, value) {
        value = value || 6378137;
        var length = 0;
        if (path instanceof t.kg) {
            path = path.getArray();
        }
        var i = 0;
        var cell_amount = path.length - 1;
        for (; i < cell_amount; ++i) {
            length = length + computeDistanceBetween(path[i], path[i + 1], value);
        }
        return length;
    },
    computeArea: function (points, width) {
        return Math.abs(this.computeSignedArea(points, width));
    },
    computeSignedArea: function (str, a) {
        a = a || 6378137;
        if (!(str instanceof Array)) {
            alert('computeSignedArray input must be Array type');
            return;
        }
        var c = str[0];
        var d = 0;
        var i = 1;
        var cell_amount = str.length - 1;
        for (; i < cell_amount; ++i) {
            d = d + this.Qk(c, str[i], str[i + 1]);
        }
        return d * a * a;
    },
    Qk: function (scope, locals, assign) {
        return this.Rk(scope, locals, assign) * this.Ml(scope, locals, assign);
    },
    Rk: function (o, x, i) {
        var n = [o, x, i, o];
        o = [];
        i = x = 0;
        for (; 3 > i; ++i) {
            o[i] = this.sg(n[i], n[i + 1]);
            x = x + o[i];
        }
        x = x / 2;
        n = Math.tan(x / 2);
        i = 0;
        for (; 3 > i; ++i) {
            n = n * Math.tan((x - o[i]) / 2);
        }
        return 4 * Math.atan(Math.sqrt(Math.abs(n)));
    },
    Ml: function (args, options, action) {
        args = [args, options, action];
        options = [];
        action = 0;
        for (; 3 > action; ++action) {
            var f = args[action];
            var e = this.LatToRadians(f);
            f = this.LngToRadians(f);
            var analytics = options[action] = [];
            analytics[0] = Math.cos(e) * Math.cos(f);
            analytics[1] = Math.cos(e) * Math.sin(f);
            analytics[2] = Math.sin(e);
        }
        return 0 < options[0][0] * options[1][1] * options[2][2] + options[1][0] * options[2][1] * options[0][2] + options[2][0] * options[0][1] * options[1][2] - options[0][0] * options[2][1] * options[1][2] - options[1][0] * options[0][1] * options[2][2] - options[2][0] * options[1][1] * options[0][2] ? 1 : -1;
    },

    
    LatToRadians: function (a) {
        a = a[0];
        return a * Math.PI / 180
    },
    LngToRadians: function (a) {
        a = a[1];
        return a * Math.PI / 180
    }

};
