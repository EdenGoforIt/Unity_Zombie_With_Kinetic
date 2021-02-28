#!C:\Users\algo\PycharmProjects\convexPractice\venv\Scripts\python.exe
# EASY-INSTALL-ENTRY-SCRIPT: 'pecan==1.3.3','console_scripts','gunicorn_pecan'
__requires__ = 'pecan==1.3.3'
import re
import sys
from pkg_resources import load_entry_point

if __name__ == '__main__':
    sys.argv[0] = re.sub(r'(-script\.pyw?|\.exe)?$', '', sys.argv[0])
    sys.exit(
        load_entry_point('pecan==1.3.3', 'console_scripts', 'gunicorn_pecan')()
    )
