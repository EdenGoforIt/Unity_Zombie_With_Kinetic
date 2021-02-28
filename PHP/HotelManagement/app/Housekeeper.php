<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Housekeeper extends Model
{
    protected $fillable = ['name'];
    public function schedules()
    {
        return $this->hasMany(Schedule::class);
    }
}
