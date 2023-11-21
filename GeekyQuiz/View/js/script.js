/// Getting all required elements
const start_btn = document.querySelector(".start_btn button");
const info_box = document.querySelector(".info_box");
const exit_btn = info_box.querySelector(".buttons .quit");
const continue_btn = info_box.querySelector(".buttons .restart");
const quiz_box = document.querySelector(".quiz_box");
const option_list = document.querySelector(".option_list");
const timeCount = quiz_box.querySelector(".timer .timer_sec");
const timeLine = document.querySelector("header .time_line");
const timeOff = document.querySelector("header .timer_text");

// If Start button clicked

// JavaScript to handle form submission and div visibility
document.getElementById("start_btn").addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent the form from submitting normally

    // Hide the registration div
    document.getElementById("start_btn").style.display = "none";

    // Show the next div
    info_box.classList.add("activeInfo"); // Show Info Box
});


// If Exit button clicked
exit_btn.onclick = () => {
    window.location.reload(); // Redirect to Start
}

// If Continue button clicked
continue_btn.onclick = () => {
    info_box.classList.remove("activeInfo"); // Hide Info Box
    quiz_box.classList.add("activeQuiz"); // Show Quiz Box
    showQuestions(0);
    queCounter(1);
    startTimer(10);
    startTimerLine(0);
}

let que_count = 0;
let que_numb = 1;
let counter;
let counterLine;
let timeValue = 10;
let widthValue = 0;
let userScore = 0;

const next_btn = quiz_box.querySelector(".next_btn");
const quit_btn = quiz_box.querySelector("footer .quit");
const result_box = document.querySelector(".result_box");
const quit_quiz = result_box.querySelector(".buttons .quit");


// If Quit button clicked
quit_quiz.onclick = () => {
    window.location.reload(); // Redirect to Start
}

// If Next button clicked
next_btn.onclick = () => {
    if (que_count < questions.length - 1) {
        que_count++;
        que_numb++;
        showQuestions(que_count);
        queCounter(que_numb);
        clearInterval(counter);
        startTimer(timeValue);
        clearInterval(counterLine);
        startTimerLine(widthValue);
        next_btn.style.display = "none";
        timeOff.textContent = "Time Left";
        timeOff.style.color = "black";
    } else {
        console.log("completed");
        showResultBox();
    }
}

// If Quit button clicked
quit_btn.onclick = () => {
    window.location.reload(); // Redirect to Start
}

// Getting questions and options from array
function showQuestions(index) {
    const que_text = document.querySelector(".que_text");
    let que_tag = '<span>' + questions[index].numb + ". " + questions[index].question + '</span>';
    let option_tag = '<div class="option"><span>' + questions[index].options[0] + '</span></div>'
        + '<div class="option"><span>' + questions[index].options[1] + '</span></div>'
        + '<div class="option"><span>' + questions[index].options[2] + '</span></div>'
        + '<div class="option"><span>' + questions[index].options[3] + '</span></div>';
    que_text.innerHTML = que_tag;
    option_list.innerHTML = option_tag;

    const option = option_list.querySelectorAll(".option");
    for (let i = 0; i < option.length; i++) {
        option[i].setAttribute("onclick", "optionSelected(this)");
    }
}

// Check Selected Answer Is Correct Or Not
let tickIcon = '<div class="icon tick"><i class="fas fa-check"></i></div>';
let crossIcon = '<div class="icon cross"><i class="fas fa-times"></i></div>';

function optionSelected(answer) {
    clearInterval(counter);
    clearInterval(counterLine);
    let userAns = answer.textContent;
    let correctAns = questions[que_count].answer;
    let allOptions = option_list.children.length;
    if (userAns == correctAns) {
        userScore += 1;
        answer.classList.add("correct");
        console.log("correct");
        answer.insertAdjacentHTML("beforeend", tickIcon);
    } else {
        answer.classList.add("incorrect");
        console.log("incorrect");
        answer.insertAdjacentHTML("beforeend", crossIcon);

        // If answer is not correct, automatically show the correct answer
        for (let i = 0; i < allOptions; i++) {
            if (option_list.children[i].textContent == correctAns) {
                option_list.children[i].setAttribute("class", "option correct");
                option_list.children[i].insertAdjacentHTML("beforeend", tickIcon);
            }
        }
    }
    // Once user select, disabled all options
    for (let i = 0; i < allOptions; i++) {
        option_list.children[i].classList.add("disabled");
    }
    next_btn.style.display = "block";
}


// Results

function showResultBox() {
    info_box.classList.remove("activeInfo");
    quiz_box.classList.remove("activeQuiz");
    result_box.classList.add("activeResult");  // Show Reults
    const scoreText = result_box.querySelector(".score_text");
    if (userScore >= 8) {
        scoreTag = '<span>and You got <p>' + userScore + '</p> out of <p>' + questions.length + '</p></span>'
        scoreText.innerHTML = scoreTag;
    }
    else if (userScore >= 5) {
        let scoreTag = '<span>and nice You got <p>' + userScore + '</p> out of <p>' + questions.length + '</p></span>'
        scoreText.innerHTML = scoreTag;
    }
    else {
        let scoreTag = '<span>and sorry You got only <p>' + userScore + '</p> out of <p>' + questions.length + '</p></span>'
        scoreText.innerHTML = scoreTag;
    }
}

// Timer Count
function startTimer(time) {
    counter = setInterval(timer, 1000);
    function timer() {
        timeCount.textContent = time;
        time--;
        if (time < 9) {
            let addZero = timeCount.textContent;
            timeCount.textContent = "0" + addZero;
        }
        if (time < 0) {
            clearInterval(counter);
            timeCount.textContent = "00";
            timeOff.textContent = "Time Off";
            timeOff.style.color = "#AB1111";

            let correctAns = questions[que_count].answer;
            let allOptions = option_list.children.length;

            // Cannot select any option after the time is zero
            for (let i = 0; i < allOptions; i++) {
                if (option_list.children[i].textContent == correctAns) {
                    option_list.children[i].setAttribute("class", "option correct");
                    option_list.children[i].insertAdjacentHTML("beforeend", tickIcon);
                }
            }
            for (let i = 0; i < allOptions; i++) {
                option_list.children[i].classList.add("disabled");
            }
            next_btn.style.display = "block";
        }
    }
}
function startTimerLine(time) {
    counterLine = setInterval(timer, 16);
    function timer() {
        time += 1;
        timeLine.style.width = time + "px";
        if (time > 700) {
            clearInterval(counterLine);
        }
    }
}

// Header Question Index
function queCounter(index) {
    const qusn_counter = quiz_box.querySelector(".quiz_box .total_que");
    let totalQuesCountTag = '<span><p>' + index + '</p> of <p>' + questions.length + '</p> Questions</span>';
    qusn_counter.innerHTML = totalQuesCountTag;
}

