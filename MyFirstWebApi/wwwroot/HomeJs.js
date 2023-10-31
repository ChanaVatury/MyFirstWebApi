const ShowRegisterTags = () => {
    const reg = document.getElementById("register")
    reg.style.visibility = "initial"

}
async function Register() {
    try {
        const UserName = document.getElementById("UserName").value;
        const Code = document.getElementById("Code").value;
        checkCode()
        //if (document.getElementById("password-strength-meter").value < 2) {
        //    alert('the password is not strength')
        //    throw new Error("please make strenghter password")
        //}
        const FirstName = document.getElementById("FirstName").value;
        const LastName = document.getElementById("LastName").value;
        const User = { UserName, Code, FirstName, LastName };

        const res = await fetch("api/users/makeuser", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(User)
        })
    
        if (!res.ok)
            throw new Error("error in adding your details to our site")
       
        const data = await res.json();
        if (data.userId == 0) {
            alert(`try again, you have an error in your information`)
        }
        else{
            alert(`new user ${data.userId} added`)
            sessionStorage.setItem("CurrentUser", JSON.stringify(data))
        }
        

    }
         catch (er) {
            alert("error..., please try again")
        } 


    
}
async function Login() {
    const UserName = document.getElementById("UserName1").value;
    const Code = document.getElementById("Code1").value;

    const res = await fetch(`api/users?userName=${UserName}&code=${Code}`) 
    if (!res.ok) {
        ShowRegisterTags()
        throw new Error("please register")
    }

    const data = await res.json();
    console.log(data, "data")
    window.location.href = './Update.html';
    sessionStorage.setItem("CurrentUser", JSON.stringify(data))

   
}
//async function GetById(id) {


//    const res = await fetch(`api/users/${id}`)
//    if (!res.ok) {
//        throw new Error("please register")
//    }

   


/*}*/
function showApdate() {
    const reg = document.getElementById("update")
    reg.style.visibility = "initial"
}
async function Update() {
    try {
    const userNow = sessionStorage.getItem("CurrentUser");
    const id = JSON.parse(userNow).userId;
    const UserName = document.getElementById("UserName").value;
    const Code = document.getElementById("Code").value;
    const FirstName = document.getElementById("FirstName").value;
    const LastName = document.getElementById("LastName").value;
    const User = { UserName, Code, FirstName, LastName };
  
        const res = await fetch(`api/users/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(User)
        })

        if (!res.ok)
            throw new Error("error in updating your details")
        const data = await res.json();
        console.log(data)
        sessionStorage.setItem("CurrentUser", JSON.stringify(data))
        alert(`the user ${data.userId} updated`)
        alert("apdated")
       
    }

    catch (er) {
        alert("error..., please try again")
    } 

}

async function checkCode() {
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    const Code = document.getElementById("Code").value;
    const res = await fetch("api/users/check", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(Code)
    })
    if (!res.ok)
        throw new Error("error in adding your details to our site")
    const data = await res.json();
    if (data <= 2) alert("your password is weak!! try again")
    // Update the password strength meter
    meter.value = data;

    // Update the text indicator
    if (Code !== "") {
        text.innerHTML = "Strength: " + strength[data.score];
    } else {
        text.innerHTML = "";
    }


}