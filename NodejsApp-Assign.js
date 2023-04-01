const http = require('http');
const fs = require('fs');
const parse = require("url").parse;
const qs = require("querystring");
const fileToStore = "DataFile1.csv"

const currDir = __dirname;
function processPost(req, res){
    let inputvalues = "";
    req.on("data", function(result){
        inputvalues += result;
    })
    req.on("end", function(){
        let postedData = qs.parse(inputvalues);
        const msg = `<p>Thanks Mr.${postedData.userName} for registering with us<p>
        U will receive an Email to ur registered Email address ${postedData["userEmail"]}</p>`;
        const entry = `${postedData.userName},${postedData.userEmail}`
        fs.appendFileSync(fileToStore,entry,'utf-8')
        res.write(msg);
        res.end();
    })
}
function showAll(res){
    const collection = [];
    const data = fs.readFileSync(fileToStore, 'utf-8')
    for(const line of data.split("\n")){
        if(line != ""){
            const words = line.split(',')
            collection.push({"name":words[0],"email":words[1]})
        }
    }
    res.write(collection)
    res.end();
}
http.createServer((req, res)=>{
    if(req.method == "GET"){
        const query = parse(req.url).query;
        if(query != null){
            processGet(req, res); 
            return;
        }
    }else if(req.method == "POST"){
            processPost(req, res);
            return;
        }
    switch (req.url) {
        case "/Register":
            fs.createReadStream(currDir + "//RegistrationForm.html").pipe(res);
            return;
        case "/showAll":
            showAll(res);
            return
    }
    
}).listen(1234);