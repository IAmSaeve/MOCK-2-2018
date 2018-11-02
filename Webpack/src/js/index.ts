// Import
import axios, { } from "../../node_modules/axios/index";

// Variables
const customerTable: HTMLTableElement = document.getElementById("customerTable") as HTMLTableElement;

const getbtn: HTMLButtonElement = document.getElementById("getAllCoinsButton") as HTMLButtonElement;
const postbtn: HTMLButtonElement = document.getElementById("postCoin") as HTMLButtonElement;
const getOnebtn: HTMLButtonElement = document.getElementById("getACoin") as HTMLButtonElement;

const getIdInput: HTMLInputElement = document.getElementById("coinId") as HTMLInputElement;

const postCoinIdInput: HTMLInputElement = document.getElementById("postCoinId") as HTMLInputElement;
const postCoinGenstandInput: HTMLInputElement = document.getElementById("postCoinGenstand") as HTMLInputElement;
const postCoinBudInput: HTMLInputElement = document.getElementById("postCoinBud") as HTMLInputElement;
const postCoinNavnInput: HTMLInputElement = document.getElementById("postCoinNavn") as HTMLInputElement;

// URL to server
let uri: string = "https://localhost:5001/api/Coin/";

// Event listeners
getbtn.addEventListener("click", ShowAllCoins);
getOnebtn.addEventListener("click", ShowACustomer);
//postbtn.addEventListener("click", PostCustomer);

function ShowAllCoins() {
    axios.get<ICoin[]>(uri)
        .then((response) => {
            // Clears list on button press
            customerTable.innerHTML = "";

            // Loop data in array and add to HTML table
            response.data.forEach((c: ICoin) => {
                const row = customerTable.insertRow();

                const ID = row.insertCell();
                const GENSTAND = row.insertCell();
                const BUD = row.insertCell();
                const NAVN = row.insertCell();

                ID.innerText = c.id.toString();
                GENSTAND.innerText = c.genstand.toString();
                BUD.innerText = c.bud.toString();
                NAVN.innerText = c.navn.toString();
            });
        });
}

function ShowACustomer() {
    axios.get<ICoin>(uri + getIdInput.valueAsNumber)
        .then((response) => {
            // Clears list on button press
            customerTable.innerHTML = "";

            // Loop data in array and add to HTML table
            const c: ICoin = response.data;
            const row = customerTable.insertRow();

            const ID = row.insertCell();
            const GENSTAND = row.insertCell();
            const BUD = row.insertCell();
            const NAVN = row.insertCell();

            ID.innerText = c.id.toString();
            GENSTAND.innerText = c.genstand.toString();
            BUD.innerText = c.bud.toString();
            NAVN.innerText = c.navn.toString();
        });
}

// function PostCustomer() {
//     // Construct data to send
//     const data: ICoin = {
//         id: null,
//         firstName: firstNameInput.value,
//         lastName: lastNameInput.value,
//         year: yearInput.valueAsNumber,
//     };

//     // Send data
//     axios.post(uri, data);

//     // Clear input fields
//     firstNameInput.value = "";
//     lastNameInput.value = "";
//     yearInput.value = "";
// }

// function PutCustomer() {
//     // Construct data to send
//     const data: ICustomer = {
//         id: putIdInput.valueAsNumber,
//         firstName: putFirstNameInput.value,
//         lastName: putLastNameInput.value,
//         year: putYearInput.valueAsNumber,
//     };

//     // Send data
//     axios.put(uri + putIdInput.value, data);

//     // Clear input fields
//     putIdInput.value = "";
//     putFirstNameInput.value = "";
//     putLastNameInput.value = "";
//     putYearInput.value = "";
// }

// function DeleteCustomer() {
//     // Send data
//     axios.delete(uri + deleteIdInput.value);

//     // Clear input field
//     deleteIdInput.value = "";
// }


// Coin interface
interface ICoin {
    id: number;
    genstand: string;
    bud: number;
    navn: string;
}