const express = require('express');
const route = express.Router();
const stdModel = require('../models/nanny');

//adding a nanny
route.post('/add',async (req,res)=>{
    const new_nanny = new stdModel({name:req.body.name, experience: req.body.experience, certified: req.body.certified, age: req.body.age});
    try {
        const newNanny = await new_nanny.save();
        res.status(201).json(newNanny);
    } catch (error) {
        return res.status(400).json({message:error.message});
    }
})

//Getting all nannies
route.get('/view', async (req, res)=>{
    try{
        const db = await stdModel.find();
        res.json(db)
        
    }catch(err){
        res.status(500).json({message:err.message})
    }
})

route.get('/view/:id', getnannyById,(req,res)=>{
    res.json(res.nanny)
})

//delete
route.delete('/delete/:id', getnannyById,async (req,res)=>{
    try {
        await res.nanny.remove();
        res.json({message:"Removed nanny"});
    } catch (error) {
        res.status(500).json({message:error.message})
    }
})

//update
route.patch('/update/:id', getnannyById,async (req,res)=>{
    console.log(req)
    if(req.body.name !== null){
        res.nanny.name = req.body.name
    }
    if(req.body.experience !== null){
        res.nanny.stream = req.body.experience
    }
    if(req.body.certified !== null){
        res.nanny.elective = req.body.certified
    }
    if(req.body.age !== null){
        res.nanny.elective = req.body.age
    }

    try {
        const stdUpdate = await res.nanny.save();
        res.json(stdUpdate);
    } catch (error) {
        res.status(400).json({message:error.message})
    }

})

async function getnannyById(req, res, next){
    let nanny;
    try{
        nanny = await stdModel.findById(req.params.id);
        if(nanny===null){
            return res.status(404).json({message:"Cannot find nanny"});
        }
    }catch(err){
        res.status(500).json({message:err.message})
    }
    res.nanny = nanny;
    next();
}

module.exports = route;