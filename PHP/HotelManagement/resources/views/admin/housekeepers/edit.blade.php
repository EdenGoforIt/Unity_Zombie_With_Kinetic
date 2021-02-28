@extends('layouts.app')

@section('content')
<h3 class="page-title">@lang('Edit')</h3>

{!! Form::model($housekeeper, ['method' => 'PUT', 'route' => ['admin.housekeepers.update', $housekeeper->id]]) !!}

<div class="panel panel-default">
    <div class="panel-heading">
        @lang('quickadmin.qa_edit')
    </div>

    <div class="panel-body">
        <div class="row">
            <div class="col-xs-12 form-group">
                {!! Form::label('name', trans('Name').'', ['class' => 'control-label']) !!}
                {!! Form::text('name', old('Name'), ['class' => 'form-control', 'placeholder' => '']) !!}
                <p class="help-block"></p>
                @if($errors->has('name'))
                <p class="help-block">
                    {{ $errors->first('name') }}
                </p>
                @endif
            </div>
        </div>


    </div>
</div>

{!! Form::submit(trans('quickadmin.qa_update'), ['class' => 'btn btn-danger']) !!}
{!! Form::close() !!}
@stop