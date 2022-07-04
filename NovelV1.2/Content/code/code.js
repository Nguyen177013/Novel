function openOpption() {
    $('.modal-Opption-dialog').addClass('open');
}
function removeOpption() {
    $('.modal-Opption-dialog').removeClass('open');
}
function openLogin() {
    $('.modal-Login-dialog').addClass('open');
}
function openCreate() {
    $('.modal-Create-dialog').addClass('open');
}
function removeLogin() {
    $('.modal-Login-dialog').removeClass('open');
} function removeCreate() {
    $('.modal-Create-dialog').removeClass('open');
}
function addType() {
    $('.modal-Type-dialog').addClass('open');
}
function removeType() {
    $('.modal-Type-dialog').removeClass('open');
}
function addBook() {
    $('.modal-Book-dialog').addClass('open');
}
function removeBook() {
    $('.modal-Book-dialog').removeClass('open');
}
function scrollDown(valuse) {
    let height = $('.main-contain').height()
    $('.read-More').click(function () {
        $('.content-Synopsis').css('max-height', height)
        $('.read-More').css({ 'top': height - 20, 'opacity': '0' })
    })
}
function openChapter() {
    $('.modal-Chapter-dialog').addClass('open');
    $('body').addClass('hidden')
}
function removeChapter() {
    $('.modal-Chapter-dialog').removeClass('open');
    $('body').removeClass('hidden')
}
// ---------------- Scroll change Event--------------------//
function scrollChange() {
    if (document.body.scrollTop > 400 || document.documentElement.scrollTop > 400) {
        $('#myBtn').css('display', 'block');
        $('#main-header').css('background-color', '#f6f7f8');
        $('#nav-header>li>a').css('color', "#000");
        $('.header-login a').css('color', "#000");
        $('.header-login').css('border-color', 'black')
        $('#nav-header li').hover(function () {
            $(this).css('background-color', 'rgba(199, 203, 209, 0.889)')
        }, function () {
            $(this).css('background-color', 'transparent')
        })
    }
    else {
        $('#nav-header>li>a').css('color', "#fff");
        $('#myBtn').css('display', 'none');
        $('.header-login').css('border-color', '#fff')
        $('.header-login a').css('color', "#fff");
        $('header').css('background-color', 'transparent');
        $('#nav-header>li').hover(function () {
            $(this).css('background-color', 'transparent')
        }, function () {
            $(this).css('border-bottom', 'none')
        })
    }
}

function showBtnSlide() {
    var number = $('.content-Finished .col-5').length;
    if (number >= 8) {
        $('.next-slide-nav').css('display', 'block')
    }

}
$(document).ready(function () {
    $('.Create-book').click(openCreate)
    removeLogin();
})
$(document).ready(function () {
    $('.type_Book').click(addType)
    $('.name_Book').click(addBook)
})
$(document).ready(function () {
    $('.modal-container').click(function (event) {
        event.stopPropagation();
    })
})
// -------------Click to close Modal----------------//
$(document).ready(function () {
    $('.modal-close').click(removeCreate)
    $('.modal-Type-dialog').click(removeType)
    $('.modal-Book-dialog').click(removeBook)
})
$(document).ready(function () {
    $('.modal-close').click(removeLogin)
})
$(document).ready(function () {
    $('#myBtn').click(function () {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        })
    })
})
//----------------Scroll event------------------//
$(document).ready(showBtnSlide)
window.onscroll = function () { scrollChange() };
$(document).ready(scrollDown)

//-----Static Color------------------------------//
let mode = localStorage.getItem('mode');
let sizeMode = localStorage.getItem('size');
let heightMode = localStorage.getItem('height');
let typeMode = localStorage.getItem('type');
/*window.onbeforeunload = function (e) {
    window.onunload = function () {
        window.localStorage.isMySessionActive = "false";
    }
    return undefined;
};

window.onload = function () {
    window.localStorage.clear();
};                                              trying to fix this :)
*/


function deepBlue() {
    $('body').css('background', 'rgb(0,59,102)')
    $('.main-story').css('color', 'white')
    $('.story_ep').css('color', 'white')
    $('.sub_side').css('color', 'white')
    localStorage.setItem('mode', 'deepBlue')
}
function slime() {
    $('body').css('background', '#e6f0e6')
    $('.main-story').css('color', 'black')
    $('.story_ep').css('color', 'black')
    $('.sub_side').css('color', 'black')
    localStorage.setItem('mode', 'slime')
}
function lightGray() {
    $('body').css('background', '#a7b1b4')
    $('.main-story').css('color', 'black')
    $('.story_ep').css('color', 'black')
    $('.sub_side').css('color', 'black')
    localStorage.setItem('mode', 'lightGray')
}
function wheat() {
    $('body').css('background', '#f6f4ec')
    $('.main-story').css('color', 'black')
    $('.story_ep').css('color', 'black')
    $('.sub_side').css('color', 'black')
    localStorage.setItem('mode', 'wheat')
}
function black() {
    $('body').css('background', '#000')
    $('.main-story').css('color', 'white')
    $('.story_ep').css('color', 'white')
    $('.sub_side').css('color', 'white')
    localStorage.setItem('mode', 'black')
}
// -------- change backgroundcolor---------------------//
$(document).ready(function () {
    if (mode == 'deepBlue') {
        deepBlue();
    }
    else if (mode == 'slime') {
        slime();
    }
    else if (mode == 'lightGray') {
        lightGray();
    }
    else if (mode == 'wheat') {
        wheat();
    }
    else if (mode == 'black') {
        black();
    }
    else {
        slime();
    }
    $('.deep-blue').click(deepBlue)
    $('.slime').click(slime)
    $('.light-gray').click(lightGray)
    $('.wheat').click(wheat)
    $('.black').click(black)
})
function textStyle(value) {
    if (value == 1)
        $('.main-story p').css('font-family', 'auto')
    if (value == 2)
        $('.main-story p').css('font-family', 'Roboto Condensed')
    if (value == 3)
        $('.main-story p').css('font-family', 'monospace')
}
//-------------Open and Close Option
$(document).ready(function () {
    $('.modal_opption').click(function () {
        openOpption()
    })
    $('.modal-Opption-dialog').click(function () {
        removeOpption();
    })
    $('.modal_info').click(function () {
        openChapter();
    })
    $('.modal-Chapter-dialog').click(function () {

        removeChapter();
    })
})

//--------------------Change fontsize - fontFamily ------------------//
$(document).ready(function () {
    var size = 1.5
    var height = 2.4
    if (sizeMode > 0 && heightMode > 0) {
        size = sizeMode;
        height = heightMode;
        $('#font-size').attr('placeholder', `${sizeMode}rem`)
        $('.main-story').css({
            'font-size': `${sizeMode}rem`,
            'line-height': `${heightMode}`
        })
    }
    $('.toUpFont').click(function () {
        size += 0.5
        height += 0.2
        $('#font-size').attr('placeholder', `${size}rem`)
        $('.main-story').css({
            'font-size': `${size}rem`,
            'line-height': `${height}`
        })
        localStorage.setItem('size', size);
        localStorage.setItem('height', size);
    })
    $('.toDownFont').click(function () {
        size -= 0.5
        height -= 0.2
        $('#font-size').attr('placeholder', `${size}rem`)
        $('.main-story').css({
            'font-size': `${size}rem`,
            'line-height': `${height}`
        })
        localStorage.setItem('size', size);
        localStorage.setItem('height', size);
    })
})

// -------------Slick Slider--------------------------//
$(document).ready(function () {
    $('.rowProduct').slick({
        slidesToShow: 5,
        autoplay: true,
        autoplaySpeed: 1000,
        arrows: false,
    });
    $('.rowProduct').on('wheel', (function (e) {
        e.preventDefault();

        if (e.originalEvent.deltaY < 0) {
            $(this).slick('slickNext');
        } else {
            $(this).slick('slickPrev');
        }
    }));
})
// --------------Toast JS -----------------------//
let toast = ({ title = '',
    message = '',
    type = 'success',
    duration }) => {
    const main = document.querySelector('#toast');
    if (main) {
        const toast = document.createElement('div');

        //auto remove 
        const autoRemove = setTimeout(function () {
            main.removeChild(toast);
        }, duration + 1000);

        //click to remove
        toast.onclick = function (e) {
            if (e.target.closest('.toast__close')) {
                main.removeChild(toast);
                clearTimeout(autoRemove)
            }
        }
        const icons = {
            success: 'fa-circle-check',
            warning: 'fa-triangle-exclamation',
            error: 'fa-circle-exclamation'
        }
        const delay = (duration / 1000).toFixed(2);
        const icon = icons[type];
        toast.classList.add('toast', `toast--${type}`);
        toast.style.animation = `slideInLeft ease 0.5s, fadeOut linear 1s ${delay}s forwards`
        toast.innerHTML = `
                <div class="toast__icon">
              <i class="fa-solid ${icon}"></i>
          </div>
          <div class="toast__body">
                <h3 class="toast__title">${title}</h3>
                <p class="toast__msg">
                    ${message}
                  </p>
              </div>
              <div class="toast__close">
                  <i class="fa-solid fa-xmark"></i>
              </div>
                `;
        main.appendChild(toast);
    }
}
let showSuccessToast = () => {
    toast({
        title: 'Thông Báo',
        message: 'Đăng nhập thành công',
        type: 'success',
        duration: 4000
    })
}
let showWarningToast = () => {
    toast({
        title: 'Thông Báo',
        message: 'Tài Khoản/Email hoặc mật khẩu không đúng',
        type: 'warning',
        duration: 4000
    })
}
let showErrorToast = () => {
    toast({
        title: 'Thông Báo',
        message: 'Có lỗi xảy ra, vui lòng lên hệ quản trị viên',
        type: 'error',
        duration: 4000
    })
}
let showSuccessToastRegister = () => {
    toast({
        title: 'Thông Báo',
        message: 'Đăng ký thành công',
        type: 'success',
        duration: 4000
    })
}
let showSuccessToastRating = () => {
    toast({
        title: 'Thông Báo',
        message: 'Cảm ơn đã đánh giá ❤',
        type: 'success',
        duration: 4000
    })
}
let showWarningToastRegister = () => {
    toast({
        title: 'Thông Báo',
        message: 'Email/Tài Khoản đã tồn tại',
        type: 'warning',
        duration: 4000
    })
}
let showWarningToastRegisterPassword = () => {
    toast({
        title: 'Thông Báo',
        message: 'Mật khẩu xác nhận không khớp!',
        type: 'warning',
        duration: 4000
    })
}
let showWarningToastRegisterEmail = () => {
    toast({
        title: 'Thông Báo',
        message: 'Vui lòng nhập Email hợp lệ!',
        type: 'warning',
        duration: 4000
    })
}
let showWarningToastPhoneNumber = () => {
    toast({
        title: 'Thông Báo',
        message: 'Vui lòng nhập Số Điện Thoại hợp lệ!',
        type: 'warning',
        duration: 4000
    })
}
let showSuccessToastChangePassword = () => {
    toast({
        title: 'Thông Báo',
        message: 'Đăng nhập thành công',
        type: 'success',
        duration: 4000
    })
}
function validateEmail(email) {
    var re = /\S+@\gmail+\.\S+/;
    return re.test(email);
}
function validPhoneNumber(numbers) {
    var re = /(84|0[3|5|7|8|9])+([0-9]{8})\b/g;
    return re.test(numbers);
}
function hashCode(string) {
    var hash = 0, i, chr;
    if (string.length === 0) return hash;
    for (i = 0; i < string.length; i++) {
        chr = string.charCodeAt(i);
        hash = ((hash << 5) - hash) + chr;
        hash |= 0;
    }
    return hash;
};