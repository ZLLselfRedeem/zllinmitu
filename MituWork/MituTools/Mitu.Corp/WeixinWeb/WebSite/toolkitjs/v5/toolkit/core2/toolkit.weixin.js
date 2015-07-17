function joinUrl(url, concat) {
    var url1 = url.split('/');
    var url2 = concat.split('/');
    var url3 = [];
    for (var i = 0, l = url1.length; i < l; i++) {
        if (url1[i] == '..') {
            url3.pop();
        } else if (url1[i] == '.') {
            continue;
        } else {
            url3.push(url1[i]);
        }
    }
    for (var i = 0, l = url2.length; i < l; i++) {
        if (url2[i] == '..') {
            url3.pop();
        } else if (url2[i] == '.') {
            continue;
        } else {
            url3.push(url2[i]);
        }
    }
    return url3.join('/');
}

function onBridgeReady() {
    var meta = $("#metaData");
    var url = document.location.href.sliceBefore("?");
    var title = meta.attr("data-title");
    var description = meta.attr("data-desc").substring(0, 70);
    var link = joinUrl(url, meta.attr("data-link"));
    var imgUrl = joinUrl(url, meta.attr("data-img"));

    // 发送给好友; 
    WeixinJSBridge.on('menu:share:appmessage', function (argv) {
        WeixinJSBridge.invoke('sendAppMessage', {
            //"appid"      : appId,
            "img_url": imgUrl,
            "img_width": "640",
            "img_height": "640",
            "link": link,
            "desc": description,
            "title": title
        }, function (res) {
            _report('send_msg', res.err_msg);
        });
    });

    // 分享到朋友圈;
    WeixinJSBridge.on('menu:share:timeline', function (argv) {
        WeixinJSBridge.invoke('shareTimeline', {
            "img_url": imgUrl,
            "img_width": "640",
            "img_height": "640",
            "link": link,
            //"desc": description,
            "title": description
        }, function (res) {
            _report('timeline', res.err_msg)
        });

    });

    // 分享到微博;
    WeixinJSBridge.on('menu:share:weibo', function (argv) {
        WeixinJSBridge.invoke('shareWeibo', {
            "content": description,
            "url": link
        }, function (res) {
            _report('weibo', res.err_msg);
        });
    });

    // 分享到Facebook
    WeixinJSBridge.on('menu:share:facebook', function (argv) {
        WeixinJSBridge.invoke('shareFB', {
            "img_url": imgUrl,
            "img_width": "640",
            "img_height": "640",
            "link": link,
            "desc": description,
            "title": title
        }, function (res) { });
    });
}

document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
