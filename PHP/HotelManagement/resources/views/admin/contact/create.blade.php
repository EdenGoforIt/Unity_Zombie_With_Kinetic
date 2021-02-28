@extends('layouts.app')
<!-- ['name','address','phone','details']; -->
@section('content')
@include('flash::message')
{!! Form::open(['route' => 'admin.contact.store']) !!}

<div class="form-group">
    {!! Form::label('name', 'Your Name') !!}
    {!! Form::text('name', null, ['class' => 'form-control']) !!}
</div>

<div class="form-group">
    {!! Form::label('email', 'E-mail Address') !!}
    {!! Form::text('email', null, ['class' => 'form-control']) !!}
</div>

<div class="form-group">
    {!! Form::textarea('msg', null, ['class' => 'form-control']) !!}
</div>

{!! Form::submit('Submit', ['class' => 'btn btn-success']) !!}

{!! Form::close() !!}

<script>
    $('#flash-overlay-modal').modal();
</script>
@stop