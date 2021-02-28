@inject('request', 'Illuminate\Http\Request')
@extends('layouts.app')

@section('content')
<h3 class="page-title">Housekeeper</h3>

<p>
    <a href="{{ route('admin.housekeepers.create') }}" class="btn btn-success">@lang('quickadmin.qa_add_new')</a>

</p>



<p>
    <ul class="list-inline">
        <li><a href="{{ route('admin.housekeepers.index') }}" style="{{ request('show_deleted') == 1 ? '' : 'font-weight: 700' }}">@lang('quickadmin.qa_all')</a></li> |
        <li><a href="{{ route('admin.housekeepers.index') }}?show_deleted=1" style="{{ request('show_deleted') == 1 ? 'font-weight: 700' : '' }}">@lang('quickadmin.qa_trash')</a></li>
    </ul>
</p>



<div class="panel panel-default">
    <div class="panel-heading">
        @lang('quickadmin.qa_list')
    </div>

    <div class="panel-body table-responsive">
        <table class="table table-bordered table-striped">
            <thead>
                <tr>
                    <th>Name</th>

                    @if( request('show_deleted') == 1 )
                    <th>&nbsp;</th>
                    @else
                    <th>&nbsp;</th>
                    @endif
                </tr>
            </thead>

            <tbody>
                @if (count($housekeepers) > 0)
                @foreach ($housekeepers as $housekeeper)
                <tr data-entry-id="{{ $housekeeper->id }}">

               


                    <td field-key='name'>{{ $housekeeper->name }}</td>

                    @if( request('show_deleted') == 1 )
                    <td>

                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'POST',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.housekeepers.restore', $housekeeper->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_restore'), array('class' => 'btn btn-xs btn-success')) !!}
                        {!! Form::close() !!}

                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'DELETE',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.housekeepers.perma_del', $housekeeper->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_permadel'), array('class' => 'btn btn-xs btn-danger')) !!}
                        {!! Form::close() !!}

                    </td>
                    @else
                    <td>

                        <a href="{{ route('admin.housekeepers.show',[$housekeeper->id]) }}" class="btn btn-xs btn-primary">@lang('quickadmin.qa_view')</a>

                        <a href="{{ route('admin.housekeepers.edit',[$housekeeper->id]) }}" class="btn btn-xs btn-info">@lang('quickadmin.qa_edit')</a>

                        {!! Form::open(array(
                        'style' => 'display: inline-block;',
                        'method' => 'DELETE',
                        'onsubmit' => "return confirm('".trans("quickadmin.qa_are_you_sure")."');",
                        'route' => ['admin.housekeepers.destroy', $housekeeper->id])) !!}
                        {!! Form::submit(trans('quickadmin.qa_delete'), array('class' => 'btn btn-xs btn-danger')) !!}
                        {!! Form::close() !!}

                    </td>
                    @endif
                </tr>
                @endforeach
                @else
                <tr>
                    <td colspan="8">@lang('quickadmin.qa_no_entries_in_table')</td>
                </tr>
                @endif
            </tbody>
        </table>
    </div>
</div>
@stop

@section('javascript')
<script>
    @can('agency_delete')
    @if(request('show_deleted') != 1) window.route_mass_crud_entries_destroy = '{{ route('
    admin.housekeepers.mass_destroy ') }}';
    @endif
    @endcan
</script>
@endsection