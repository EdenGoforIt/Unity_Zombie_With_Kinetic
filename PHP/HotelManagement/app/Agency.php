<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Agency extends Model
{
    protected $fillable=['name','address','phone','details'];
    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }
}
