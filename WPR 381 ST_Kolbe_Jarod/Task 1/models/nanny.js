const mongoose = require('mongoose')

const nanny_Schema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
    },
    experience: {
        type: String,
        required: true,
        enum: {
            values: ['Baic', 'Intermediate', 'Advanced'],
            message: "Select experience"
        }
    },
    certified: {
        type: Boolean,
        required: true,
        default: false,
    },
    age:
    {
        type: Number,
        required: true,
    }
})

module.exports = mongoose.model('nannies',nanny_Schema);