@extends('layouts.app')

@section('content')
<h3 class="page-title">@lang('quickadmin.rooms.title')</h3>
{!! Form::open(['method' => 'POST', 'route' => ['admin.rooms.store']]) !!}

<div class="panel panel-default">
    <div class="panel-heading">
        @lang('quickadmin.qa_create')
    </div>

    <div class="panel-body">
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('room_number', 'Room Number', ['class' => 'control-label']) !!}
                {!! Form::select('room_number', [101,102,103,201, 202, 203, 301, 302, 303], old('room_number'), ['class' => 'form-control select2']) !!}

                <p class="help-block"></p>
                @if($errors->has('room_number'))
                <p class="help-block">
                    {{ $errors->first('room_number') }}
                </p>
                @endif
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('floor', 'Floor', ['class' => 'control-label']) !!}
                {!! Form::select('floor', ['1F', '2F', '3F'], old('floor'), ['class' => 'form-control select2']) !!}

                <p class="help-block"></p>
                @if($errors->has('floor'))
                <p class="help-block">
                    {{ $errors->first('floor') }}
                </p>
                @endif
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('room_status', 'Room Status', ['class' => 'control-label']) !!}
                {!! Form::select('room_status', ['vacantClean','vacantDirty','occupiedClean','occupiedService','onMaintenance'], old('room_status'), ['class' => 'form-control select2']) !!}

                <p class="help-block"></p>
                @if($errors->has('room_status'))
                <p class="help-block">
                    {{ $errors->first('room_status') }}
                </p>
                @endif
            </div>
        </div>


        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('description', trans('quickadmin.rooms.fields.description').'*', ['class' => 'control-label']) !!}
                {!! Form::textarea('description', old('description'), ['class' => 'form-control ', 'placeholder' => '', 'required' => '']) !!}
                <p class="help-block"></p>
                @if($errors->has('description'))
                <p class="help-block">
                    {{ $errors->first('description') }}
                </p>
                @endif
            </div>
        </div>



    </div>
</div>

{!! Form::submit(trans('quickadmin.qa_save'), ['class' => 'btn btn-danger']) !!}
{!! Form::close() !!}
@stop