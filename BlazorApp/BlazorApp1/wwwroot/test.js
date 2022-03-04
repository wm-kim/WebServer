// 간단한 팝업이나 입력 박스, 간단한 작업만 할것임
// javascript 문법을 모르더라도 대충 느낌만 보면 됨
// javascript에서는 명시적으로 datatype을 지정하지 않지만 내부적으로 type이 있음
// 함수도 기본형식 중 하나
// js나 python같은 경우 type명시 안함. runtime에 어떤 type인지 보고 알아서 판별
// 컴파일 타임에서 error을 잡아주지못함

var func = (function () {

    window.testFunction = {
        helloWorld: function () {
            // void 반환
            return alert('Hello world');
        },
        inputName: function (text) {
            // string 반환
            return prompt(text, 'Input Name');
        }
    };
});

func();
// window는 browser의 조상 testFunction 객체 실시간으로 만든다.