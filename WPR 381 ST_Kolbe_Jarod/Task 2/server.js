//imports
const express = require('express');
const app = express();
const ejs = require('ejs')
app.set('view engine', 'ejs')
app.use(express.urlencoded({extended:true}))
let nannies = [{name: 'Lilly', experience: 'Advanced', certification: 'true', age: 30}]
let nanniesFilter =[]

//starting server
const port = 3200;
app.listen(port,()=>console.log("Server running on port: "+ port))

//routes
app.get('/', (req, res)=>{
    res.render('index')
})
//adding a nanny
app.post('/view', (req,res)=>{
    nannies.push(req.body) 
    console.log(req.body)
    res.render('view', {nannies, nanniesFilter})
})

//Getting all nannies
app.get('/view', (req, res)=>{
    nanniesFilter = []
    res.render('view', {nannies, nanniesFilter})
})

app.get('/view/Basic', (req,res)=>{
    nanniesFilter = []
    for (let i = 0; i < nannies.length; i++) {
        if (nannies[i].experience == 'Basic') {
            nanniesFilter.push(nannies[i]);
        }
    }
    res.render('view', {nannies, nanniesFilter})
})

app.get('/view/Intermediate', (req,res)=>{
    nanniesFilter = []
    for (let i = 0; i < nannies.length; i++) {
        if (nannies[i].experience == 'Intermediate') {
            nanniesFilter.push(nannies[i]);
        }
    }
    res.render('view', {nannies, nanniesFilter})
})

app.get('/view/Advanced', (req,res)=>{
    nanniesFilter = []
    for (let i = 0; i < nannies.length; i++) {
        if (nannies[i].experience == 'Advanced') {
            nanniesFilter.push(nannies[i]);
        }
    }
    res.render('view', {nannies, nanniesFilter})
})

