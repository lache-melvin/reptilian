FROM mcr.microsoft.com/dotnet/sdk:5.0.402

# -m creates home folder for reptile
# -s sets shell (bash)
RUN useradd -m -s $(which bash) reptile

# Create workdir /app, give ownership to reptile
# Ownership is preserved when mounting volume to /app
RUN mkdir /app && chown reptile:reptile /app

USER reptile

ENV PATH "$PATH:/home/reptile/.dotnet/tools"
