//imports
require('dotenv').config();
const mongoose = require('mongoose')
const bp = require('body-parser')
const express = require('express');
const app = express();

//connecting to the database
mongoose.connect(process.env.DATABASE_URL,{
    useNewUrlParser:true,
    useUnifiedTopology: true,
})

//getting db 
const db = mongoose.connection;

//checking connection
db.on('error',(err)=>console.error(err))
db.once('open',()=>console.log('Connected successfully to the db'))

app.use(bp.json())
const stdRoute = require("./routes/nanny")

app.use("/nanny",stdRoute)

//starting server
const port = 8000;
app.listen(port,()=>console.log("Server running on port: "+ port))