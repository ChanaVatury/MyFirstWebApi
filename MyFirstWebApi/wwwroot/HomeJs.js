//Add folders - scripts, style(css) etc... arrange the files in folders!
//I recommend to change the project name to webApiShopSite etc. 


const ShowRegisterTags = () => {
    const reg = document.getElementById("register")
    reg.style.visibility = "initial"

}
async function Register() {
    try {
        const Email = document.getElementById("Email").value;
        const Passwordd = document.getElementById("Passwordd").value;
        checkCode()
        //if (document.getElementById("password-strength-meter").value < 2) {
        //    alert('the password is not strength')
        //    throw new Error("please make strenghter password")
        //}
        const FirstName = document.getElementById("FirstName").value;
        const LastName = document.getElementById("LastName").value;
        const User = { Email, Passwordd, FirstName, LastName };

        const res = await fetch("api/users/", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(User)
        })
    
        if (!res.ok)
        //alert("Registration failed")
            throw new Error("error in adding your details to our site")
        //Check response status code- if response is ok..., if not alert a suitable message...
        const data = await res.json();
        //??? - data.userId == 0 ??  if creation failed you should get 400 status code.
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
          //Alerting errors to the user is not recommended, log them to the console.

        } 
        
        
    
}
async function Login() {
   //clean code- by Convention: Variables and functions names begin with a lowercase letter. (login, email, password)
    const data.userId == 0 = document.getElementById("Email1").value;
    const Passwordd = document.getElementById("Passwordd1").value;

    const res = await fetch(`api/users?userName=${Email}&code=${Passwordd}`) 
    if (!res.ok) {
        ShowRegisterTags()
        //Instead of throwing an error alert a suitable message. 
        throw new Error("please register")
    }
    const data = await res.json();
    console.log(data);

    sessionStorage.setItem("CurrentUser", JSON.stringify(data));
    window.location.href = './Update.html';
   
}
//async function GetById(id) {


//    const res = await fetch(`api/users/${id}`)
//    if (!res.ok) {
//        throw new Error("please register")
//    }




/*}*/
//showUpdateForm(Apdate- spelling!)
function showApdate() {
    const reg = document.getElementById("update")
    reg.style.visibility = "initial"
}
async function Update() {
    try {
    const userNow = sessionStorage.getItem("CurrentUser");
    const id = JSON.parse(userNow).userId;
        const Email = document.getElementById("Email").value;
        const Passwordd = document.getElementById("Passwordd").value;
    const FirstName = document.getElementById("FirstName").value;
    const LastName = document.getElementById("LastName").value;
        const User = { Email, Passwordd, FirstName, LastName };
  
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
        //Remove the next alert
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
    const Passwordd = document.getElementById("Passwordd").value;
    const res = await fetch("api/users/check", {
        method: "POST",
        headers: {//
            "Content-Type": "application/json"
        },
        body: JSON.stringify(Passwordd)
    })
    if (!res.ok)
        throw new Error("error in adding your details to our site")
    const data = await res.json();
  /*  if (data <= 2) alert("your password is weak!! try again")*/
    // Update the password strength meter
    meter.value = data;

    // Update the text indicator
    if (Passwordd !== "") {
        text.innerHTML = "Strength: " + strength[data.score];
    } else {
        text.innerHTML = "";
    }


}