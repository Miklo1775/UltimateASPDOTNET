document.querySelector("#load-cats-button").addEventListener("click", async (e) => {
  const response = await fetch("cats-list", {
        method: "GET"
    })
    
    const body = await response.text();
  document.querySelector("#list").innerHTML = body;
    
})