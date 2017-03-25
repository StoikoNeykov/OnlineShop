var custom = (function () {
    // magical number: pixels from end where fire infinite scroll event
    let pixels = 5;

    $(".button-collapse").sideNav();

    $('.carousel').carousel({ full_width: true });
    $('.carousel-slider').slider({ full_width: true });

    let requester = {
        get(url, body, headers) {
            let promise = new Promise((resolve, reject) => {
                $.ajax({
                    url,
                    method: "GET",
                    headers,
                    contentType: 'application/json',
                    data: JSON.stringify(body),
                    success(response) {
                        resolve(response);
                    },
                    error(err) {
                        reject(err);
                    }
                });
            });

            return promise;
        }
    };

    let defaultCreateItemCallback = function (item) {
        console.log(item);
        let $sizedDiv = $('<div />').addClass('card-sizer');
        let $wrapper = $('<div />').addClass('card');
        let $actionDiv = $('<div />').addClass('card-action');
        let $cardImageDiv = $('<div />').addClass('card-image');
        let $img = $('<img>').attr('src', item.ImageUrl);
        let $titleSpan = $('<span />').addClass('card-title').val(item.Name);
        let $link = $('<a />').prop('href', item.Link).text(item.Name);

        $cardImageDiv.append($img);
        $cardImageDiv.append($titleSpan);
        $actionDiv.append($link);

        $wrapper.append($cardImageDiv);
        $wrapper.append($actionDiv);
        $sizedDiv.append($wrapper);
        return $sizedDiv;
    };

    let addItems = function (selector, url, page, createItemCallback) {
        let $items = $(selector);
        page = page || 0;
        createItemCallback = createItemCallback || defaultCreateItemCallback;

        requester.get(url, { page: page })
            .then(data => {
                data.data.forEach(x => {
                    let element = createItemCallback(x);
                    
                    $items.append(element);
                });
            })
            .catch(err => console.log(err));
    };

    let infiniteScroll = function (selector, url, createItemCallback) {
        let currentPage = 1;

        addItems(selector, url, createItemCallback)

        $(window).scroll(function () {
            if ($(window).scrollTop() + $(window).height() > $(document).height() - pixels) {
                currentPage++;
                addItems(selector, url, currentPage, createItemCallback);
            }
        });
    };

    return {
        infiniteScroll
    };
})();